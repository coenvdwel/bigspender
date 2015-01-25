using BigSpender.Objects;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace BigSpender.Parse
{
  // ReSharper disable once InconsistentNaming
  public static class ING
  {
    public static bool IsValid(string path)
    {
      if (!path.ToLower().EndsWith(".csv")) return false;
      var s = File.ReadAllLines(path).First();

      return s == "\"Datum\",\"Naam / Omschrijving\",\"Rekening\",\"Tegenrekening\",\"Code\",\"Af Bij\",\"Bedrag (EUR)\",\"MutatieSoort\",\"Mededelingen\"";
    }

    public static void Parse(Manager manager, string path)
    {
      var lines = File.ReadAllLines(path).Skip(1).ToList();
      foreach (var s in lines.Select(line => line.Split(new[] {"\",\""}, StringSplitOptions.None)))
      {
        s[0] = s[0].Substring(1);
        s[8] = s[8].Substring(0, s[8].Length - 1);

        if (s[3] == String.Empty)
        {
          s[3] = s[7];
          s[1] = s[7];
        }

        var fromAccount = manager.GetOrCreateAccount(s[2], s[1]);
        var toAccount = manager.GetOrCreateAccount(s[3], s[1]);

        manager.AddMutation(new Mutation
        {
          Date = DateTime.ParseExact(s[0], "yyyyMMdd", CultureInfo.InvariantCulture),
          Name = s[1].Trim(),
          FromAccount = fromAccount,
          ToAccount = toAccount,
          Code = s[4].Trim(),
          Quantity = Decimal.Parse(s[6], CultureInfo.GetCultureInfo("NL"))*(s[5] == "Af" ? -1 : 1),
          Type = s[7].Trim(),
          Remark = s[8].Trim()
        });
      }
    }
  }
}