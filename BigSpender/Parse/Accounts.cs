using BigSpender.Objects;
using System;
using System.IO;
using System.Linq;

namespace BigSpender.Parse
{
  public static class Accounts
  {
    public static bool IsValid(string path)
    {
      if (!path.ToLower().EndsWith(".csv")) return false;
      var s = File.ReadAllLines(path).First();

      return s == "\"AccountNumber\",\"Category\",\"Name\",\"Type\"";
    }

    public static void Parse(Manager manager, string path)
    {
      var lines = File.ReadAllLines(path).Skip(1).ToList();
      foreach (var s in lines.Select(line => line.Split(new[] {"\",\""}, StringSplitOptions.None)))
      {
        s[0] = s[0].Substring(1);
        s[3] = s[3].Substring(0, s[3].Length - 1);

        var accounts = s[0].Split('|');
        var other = accounts.Skip(1).ToList();

        var type = s[3] == "Owned"
          ? AccountType.Owned
          : s[3] == "Periodic"
            ? AccountType.Periodic
            : AccountType.Other;

        manager.GetOrCreateAccount(accounts[0], s[2], other, s[1], type);
      }
    }
  }
}