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

    private static decimal _deviationFactor = 0.25m;

    public DateTime GetLastDate()
    {
      return Mutations.GroupBy(x => x.Date.Month).Where(x => Math.Abs(x.Sum(m => m.Quantity)) > (Math.Abs(PeriodicQuantity.Value) * (1 - _deviationFactor))).Select(x => (DateTime?)x.Max(m => m.Date)).OrderByDescending(x => x).FirstOrDefault()
           ?? Mutations.Where(x => Math.Abs(x.Quantity) > (Math.Abs(PeriodicQuantity.Value) * (1 - _deviationFactor))).Select(x => (DateTime?)x.Date).OrderByDescending(x => x).FirstOrDefault()
           ?? Mutations.Select(x => (DateTime?)x.Date).OrderByDescending(x => x).FirstOrDefault()
           ?? DateTime.MinValue;
    }

    private List<Mutation> GetRegularRecentMutations(int period = 12)
    {
      var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-period);
      var mutations = Mutations.Where(x => x.Date >= date).ToList();

      if (!mutations.Any()) return new List<Mutation>();

      var monthlyMutations = mutations.GroupBy(x => x.Date.Month);

      var medianSums = monthlyMutations.Select(x => x.Sum(m => m.Quantity)).OrderBy(x => x).ToList();
      var median = medianSums[medianSums.Count / 2];

      if (medianSums.Count % 2 == 0)
      {
        median = (medianSums[medianSums.Count / 2 - 1] + median) / 2m;
      }

      var min = Math.Min(median * (1 - _deviationFactor), median * (1 + _deviationFactor));
      var max = Math.Max(median * (1 - _deviationFactor), median * (1 + _deviationFactor));

      return (from m in monthlyMutations
              let sum = m.Sum(x => x.Quantity)
              where sum >= min && sum < max
              from x in m
              select x).ToList();
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