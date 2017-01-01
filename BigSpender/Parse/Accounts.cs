using BigSpender.Interfaces;
using BigSpender.Objects;
using System;
using System.IO;
using System.Linq;

namespace BigSpender.Parse
{
  public class Accounts : IParse
  {
    public bool IsValid(string path)
    {
      if (!path.ToLower().EndsWith(".csv")) return false;
      var s = File.ReadAllLines(path).First();

      return s == "\"AccountNumber\",\"Category\",\"Name\",\"Type\",\"Periodic Day Of Month\",\"Periodic Frequency\",\"Periodic Quantity\"";
    }

    public void Parse(Manager manager, string path)
    {
      var lines = File.ReadAllLines(path).Skip(1).ToList();
      foreach (var s in lines.Select(line => line.Split(new[] { "\",\"" }, StringSplitOptions.None)))
      {
        if (s.Length != 7) continue;

        s[0] = s[0].Substring(1);
        s[6] = s[6].Substring(0, s[6].Length - 1);

        var accounts = s[0].Split('|');
        var other = accounts.Skip(1).ToList();

        var type = s[3] == "Owned"
          ? AccountType.Owned
          : s[3] == "Periodic"
            ? AccountType.Periodic
            : AccountType.Other;

        var account = manager.GetOrCreateAccount(accounts[0], s[2], other, s[1], type);

        if (type == AccountType.Periodic)
        {
          account.PeriodicDayOfMonth = String.IsNullOrEmpty(s[4]) ? (int?)null : Int32.Parse(s[4]);
          account.PeriodicFrequency = String.IsNullOrEmpty(s[5]) ? (int?)null : Int32.Parse(s[5]);
          account.PeriodicQuantity = String.IsNullOrEmpty(s[6]) ? (decimal?)null : decimal.Parse(s[6]);
        }
      }
    }
  }
}