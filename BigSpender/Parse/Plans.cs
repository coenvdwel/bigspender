using BigSpender.Interfaces;
using BigSpender.Objects;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace BigSpender.Parse
{
  public class Plans : IParse
  {
    public bool IsValid(string path)
    {
      if (!path.ToLower().EndsWith(".csv")) return false;
      var s = File.ReadAllLines(path).First();

      return s == "\"AccountNumber\",\"Date\",\"Quantity\",\"Frequency\",\"Remark\"";
    }

    public void Parse(Manager manager, string path)
    {
      var lines = File.ReadAllLines(path).Skip(1).ToList();
      foreach (var s in lines.Select(line => line.Split(new[] { "\",\"" }, StringSplitOptions.None)))
      {
        s[0] = s[0].Substring(1);
        s[4] = s[4].Substring(0, s[4].Length - 1);

        var account = manager.GetOrCreateAccount(s[0].Split('|')[0], "Plan");

        manager.AddPlan(new Plan
        {
          Account = account,
          Date = DateTime.ParseExact(s[1], "yyyyMMdd", CultureInfo.InvariantCulture),
          Quantity = Decimal.Parse(s[2], CultureInfo.GetCultureInfo("NL")),
          Frequency = Int32.Parse(s[3]),
          Remark = s[4]
        });
      }
    }
  }
}