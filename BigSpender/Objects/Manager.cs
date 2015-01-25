using BigSpender.Parse;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace BigSpender.Objects
{
  public class Manager
  {
    private readonly List<Mutation> _mutations;
    private readonly List<Account> _accounts;
    private readonly List<Plan> _plans;

    public Manager()
    {
      _mutations = new List<Mutation>();
      _accounts = new List<Account>();
      _plans = new List<Plan>();
    }

    #region Data manipulation

    public void AddFile(string path)
    {
      if (Accounts.IsValid(path)) Accounts.Parse(this, path);
      else if (Plans.IsValid(path)) Plans.Parse(this, path);
      else if (ING.IsValid(path)) ING.Parse(this, path);
    }

    public Account GetOrCreateAccount(string number, string name)
    {
      return GetOrCreateAccount(number, name, new List<string>(), "UNKNOWN", AccountType.Other);
    }

    public Account GetOrCreateAccount(string number, string name, List<string> other, string category, AccountType type)
    {
      var account = _accounts.FirstOrDefault(x => x.AccountNumber == number)
                    ?? _accounts.FirstOrDefault(x => x.OtherNumbers.Contains(number));

      if (account != null) return account;

      account = new Account
      {
        AccountNumber = number,
        OtherNumbers = other,
        Name = name,
        Category = category,
        Type = type
      };

      _accounts.Add(account);
      return account;
    }

    public void AddMutation(Mutation mutation)
    {
      _mutations.Add(mutation);
    }

    public void AddPlan(Plan plan)
    {
      _plans.Add(plan);
    }

    #endregion

    #region Get data tables

    public DataTable GetMutationTable(string account, string category)
    {
      var table = new DataTable();

      table.Columns.Add("Date", typeof(DateTime));
      table.Columns.Add("Name", typeof(string));
      table.Columns.Add("From Account", typeof(string));
      table.Columns.Add("To Account", typeof(string));
      table.Columns.Add("Category", typeof(string));
      table.Columns.Add("Code", typeof(string));
      table.Columns.Add("Quantity", typeof(decimal));
      table.Columns.Add("Type", typeof(string));
      table.Columns.Add("Remark", typeof(string));

      foreach (var m in _mutations
        .Where(m => String.IsNullOrEmpty(account) || m.ToAccount.AccountNumber.ToLower().Contains(account.ToLower()))
        .Where(m => String.IsNullOrEmpty(category) || m.ToAccount.Category.ToLower().Contains(category.ToLower())))
      {
        table.Rows.Add(m.Date, m.Name, m.FromAccount.AccountNumber, m.ToAccount.AccountNumber, m.ToAccount.Category, m.Code, m.Quantity, m.Type,
          m.Remark);
      }

      return table;
    }

    public DataTable GetAccountTable(string account, string category)
    {
      var table = new DataTable();

      table.Columns.Add("Account", typeof(string));
      table.Columns.Add("Name", typeof(string));
      table.Columns.Add("Category", typeof(string));
      table.Columns.Add("# Positive bookings", typeof(int));
      table.Columns.Add("# Negative bookings", typeof(int));
      table.Columns.Add("Periodic date", typeof(int));
      table.Columns.Add("Periodic frequency", typeof(int));
      table.Columns.Add("Periodic quantity", typeof(decimal));
      table.Columns.Add("Saldi", typeof(decimal));

      foreach (var a in _accounts
        .Where(a => String.IsNullOrEmpty(account) || a.AccountNumber.ToLower().Contains(account.ToLower()))
        .Where(a => String.IsNullOrEmpty(category) || a.Category.ToLower().Contains(category.ToLower())))
      {
        table.Rows.Add(a.AccountNumber, a.Name, a.Category, a.Mutations.Count(m => m.Quantity > 0),
          a.Mutations.Count(m => m.Quantity < 0), a.PeriodicDayOfMonth, a.PeriodicFrequency,
          a.PeriodicQuantity, a.Mutations.Sum(x => x.Quantity));
      }

      return table;
    }

    public DataTable GetMonthTable(MonthViewMode mode, int history)
    {
      var table = new DataTable();
      var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

      table.Columns.Add("Account", typeof(string));
      table.Columns.Add("Name", typeof(string));
      table.Columns.Add("Category", typeof(string));

      for (var i = history - 1; i >= 0; i--)
      {
        var month = date.AddMonths(-i).ToString("MMM yy", CultureInfo.InvariantCulture);
        table.Columns.Add(month, typeof(decimal));
      }

      foreach (var a in _accounts)
      {
        if (a.Type == AccountType.Owned) continue;
        if (a.Type != AccountType.Periodic && mode == MonthViewMode.Registered) continue;
        if (a.Type == AccountType.Periodic && mode == MonthViewMode.Predicted) continue;

        var data = new object[3 + history];
        var count = 0;

        data[0] = a.AccountNumber;
        data[1] = a.Name;
        data[2] = a.Category;

        for (var i = history - 1; i >= 0; i--)
        {
          var fromDate = date.AddMonths(-i);
          var toDate = date.AddMonths(-(i - 1));

          var quantity = (from m in _mutations
                          where m.ToAccount == a
                                && m.Date >= fromDate
                                && m.Date < toDate
                          select m.Quantity).Sum();

          if (quantity == 0) continue;

          data[(history - i - 1) + 3] = quantity;
          count++;
        }

        if (count > 0 && (mode != MonthViewMode.Predicted || (count > 2))) table.Rows.Add(data);
      }

      return table;
    }

    public DataTable GetPlansTable()
    {
      var table = new DataTable();

      table.Columns.Add("Account", typeof(string));
      table.Columns.Add("Date", typeof(DateTime));
      table.Columns.Add("Frequency", typeof(int));
      table.Columns.Add("Quantity", typeof(decimal));
      table.Columns.Add("Remark", typeof(string));

      foreach (var p in _plans)
      {
        table.Rows.Add(p.Account.AccountNumber, p.Date, p.Frequency, p.Quantity, p.Remark);
      }

      return table;
    }

    public DataTable GetCashFlow(int forecast)
    {
      var plans = new List<Plan>();
      var table = new DataTable();
      var until = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(forecast);

      table.Columns.Add("Date", typeof(DateTime));
      table.Columns.Add("Remark", typeof(string));
      table.Columns.Add("Account", typeof(string));
      table.Columns.Add("Name", typeof(string));
      table.Columns.Add("Category", typeof(string));
      table.Columns.Add("Quantity", typeof(decimal));
      table.Columns.Add("Running", typeof(decimal));

      foreach (var a in _accounts)
      {
        if (a.Type != AccountType.Periodic) continue;
        if (!a.Mutations.Any()) continue;

        var frequency = a.PeriodicFrequency;
        var quantity = a.PeriodicQuantity;
        var day = a.PeriodicDayOfMonth;

        if (a.AccountNumber == "NL82RABO0350519137")
        {
          day = day + 1;
          day--;
        }

        if (!frequency.HasValue || frequency == 0) continue;
        if (!quantity.HasValue || quantity == 0) continue;
        if (!day.HasValue) continue;

        var date = (from x in a.Mutations
                    where Math.Abs(x.Quantity) > (Math.Abs(quantity.Value) * (1 - Account.DeviationFactor))
                    orderby x.Date descending
                    select (DateTime?)x.Date).FirstOrDefault()
                    ?? (from x in a.Mutations
                        orderby x.Date descending
                        select x.Date).First();

        var remark = String.Empty;

        // correct date in case of deviation
        var dev = date.Day - day.Value;
        if (Math.Abs(dev) > 2 && Math.Abs(dev) < 27)
        {
          remark = String.Format("Date corrected, last mutation was on day {0} but the regular day is {1}.", date.Day, day.Value);
          date = date.AddDays(-dev);
        }

        var months = 12 / frequency;
        while (true)
        {
          date = date.AddMonths(months.Value);
          if (date > until) break;

          plans.Add(new Plan
          {
            Date = date,
            Account = a,
            Quantity = quantity.Value,
            Remark = remark
          });
        }
      }

      foreach (var plan in _plans)
      {
        var date = plan.Date;
        var months = 12 / plan.Frequency;

        while(true)
        {
          date = date.AddMonths(months);

          if (date > until) break;
          if (date < DateTime.Today) continue;
          
          plans.Add(new Plan
          {
            Date = date,
            Account = plan.Account,
            Quantity = plan.Quantity,
            Remark = plan.Remark
          });
        }
      }

      if (!plans.Any()) return table;
      plans = plans.OrderBy(x => x.Date).ToList();

      var s = 0m;
      var m = 0m;

      foreach (var p in plans)
      {
        s += p.Quantity;
        if (s < m) m = s;
      }

      table.Rows.Add(plans[0].Date, "BEGINSTAND", "BEGINSTAND", "BEGINSTAND", "BEGINSTAND", -m, -m);

      s = -m;
      foreach (var p in plans)
      {
        s += p.Quantity;
        table.Rows.Add(p.Date, p.Remark, p.Account.AccountNumber, p.Account.Name, p.Account.Category, p.Quantity, s);
      }

      table.Rows.Add(plans[plans.Count - 1].Date, "EINDSTAND", "EINDSTAND", "EINDSTAND", "EINDSTAND", s, s);

      return table;
    }

    #endregion
  }
}