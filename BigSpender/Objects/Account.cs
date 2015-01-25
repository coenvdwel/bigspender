using System;
using System.Collections.Generic;
using System.Linq;

namespace BigSpender.Objects
{
  public class Account
  {
    public List<Mutation> Mutations;
    public string Name;
    public string Category;
    public AccountType Type;
    public string AccountNumber;
    public List<string> OtherNumbers;

    #region Extensions

    private int? _periodicDayOfMonth;
    public int? PeriodicDayOfMonth
    {
      get
      {
        if (_periodicDayOfMonth.HasValue) return _periodicDayOfMonth;
        return GetPeriodicDayOfMonth();
      }
      set { _periodicDayOfMonth = value; }
    }

    private int? _periodicFrequency;
    public int? PeriodicFrequency
    {
      get
      {
        if (_periodicFrequency.HasValue) return _periodicFrequency;
        return GetPeriodicFrequency();
      }
      set { _periodicFrequency = value; }
    }

    private decimal? _periodicQuantity;
    public decimal? PeriodicQuantity
    {
      get
      {
        if (_periodicQuantity.HasValue) return _periodicQuantity; 
        return GetPeriodicQuantity();
      }
      set { _periodicQuantity = value; }
    }

    public static decimal DeviationFactor = 0.25m;

    private List<Mutation> GetRegularRecentMutations(int period = 12)
    {
      var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

      var mutations = (from m in Mutations
                       where m.Date >= date.AddMonths(-period)
                       orderby m.Quantity
                       select m).ToList();

      if (!mutations.Any()) return mutations;

      decimal median;
      if (mutations.Count % 2 == 0)
      {
        var a = mutations[mutations.Count / 2 - 1].Quantity;
        var b = mutations[mutations.Count / 2].Quantity;
        median = (a + b) / 2m;
      }
      else
      {
        median = mutations[mutations.Count / 2].Quantity;
      }

      var min = Math.Min((median * (1 - DeviationFactor)), (median * (1 + DeviationFactor)));
      var max = Math.Max((median * (1 - DeviationFactor)), (median * (1 + DeviationFactor)));

      return (from m in mutations
              where m.Quantity >= min
                    && m.Quantity < max
              select m).ToList();
    }

    private int? GetPeriodicDayOfMonth()
    {
      if (Type != AccountType.Periodic) return null;

      var mutations = GetRegularRecentMutations();
      if (!mutations.Any()) return 0;

      return (from x in mutations.GroupBy(x => x.Date.Day)
              orderby x.Count() descending
              select x.Key).First();
    }

    private int? GetPeriodicFrequency()
    {
      if (Type != AccountType.Periodic) return null;

      var frequency = GetRegularRecentMutations(12).Count();

      if (frequency <= 0) return 0;
      if (frequency <= 2) return 1;
      if (frequency <= 4) return 3;
      if (frequency <= 7) return 6;
      //if (frequency > 13) return 24;
      
      return 12;
    }

    private decimal? GetPeriodicQuantity()
    {
      var mutations = GetRegularRecentMutations(3);
      if (!mutations.Any()) return null;

      return decimal.Round(mutations.Average(x => x.Quantity), 2, MidpointRounding.AwayFromZero);
    }

    #endregion

    public Account()
    {
      OtherNumbers = new List<string>();
      Mutations = new List<Mutation>();
    }
  }
}