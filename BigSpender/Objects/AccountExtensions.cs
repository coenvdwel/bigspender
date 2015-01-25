using System;
using System.Collections.Generic;
using System.Linq;

namespace BigSpender.Objects
{
  public static class AccountExtensions
  {
    public static decimal DeviationFactor = 0.25m;

    public static List<Mutation> GetRegularRecentMutations(this Account account, int period = 12)
    {
      var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

      var mutations = (from m in account.Mutations
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

    public static int? GetPeriodicDayOfMonth(this Account account)
    {
      if (account.Type != AccountType.Periodic) return null;

      var mutations = account.GetRegularRecentMutations();
      if (!mutations.Any()) return 0;

      return (from x in mutations.GroupBy(x => x.Date.Day)
              orderby x.Count() descending
              select x.Key).First();
    }

    public static int? GetPeriodicFrequency(this Account account)
    {
      if (account.Type != AccountType.Periodic) return null;

      var frequency = account.GetRegularRecentMutations().Count();

      if (frequency <= 0) frequency = 0;
      else if (frequency <= 2) frequency = 1;
      else if (frequency <= 4) frequency = 3;
      else if (frequency <= 7) frequency = 6;
      else frequency = 12;

      return frequency;
    }

    public static decimal? GetPeriodicQuantity(this Account account)
    {
      var mutations = account.GetRegularRecentMutations(3);
      if(!mutations.Any()) return null;

      return decimal.Round(mutations.Average(x => x.Quantity), 2, MidpointRounding.AwayFromZero);
    }
  }
}