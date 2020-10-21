using BigSpender.Interfaces;
using BigSpender.Objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace BigSpender.Parse
{
  public class ING : IParse
  {
    public bool IsValid(string path)
    {
      if (!path.ToLower().EndsWith(".csv")) return false;
      var s = File.ReadAllLines(path).First();

      return s.Equals("\"Datum\",\"Naam / Omschrijving\",\"Rekening\",\"Tegenrekening\",\"Code\",\"Af Bij\",\"Bedrag (EUR)\",\"Mutatiesoort\",\"Mededelingen\"", StringComparison.OrdinalIgnoreCase);
    }

    public void Parse(Manager manager, string path)
    {
      var lines = File.ReadAllLines(path).Skip(1).ToList();
      foreach (var s in lines.Select(line => line.Split(new[] { "\",\"" }, StringSplitOptions.None)))
      {
        if (s.Length != 9) continue;

        s[0] = s[0].Substring(1);
        s[8] = s[8].Substring(0, s[8].Length - 1);

        var mappings = new Dictionary<string, Dictionary<string, string[]>>
        {
            { "Supermarkt", new Dictionary<string, string[]> {
              { "Albert Heijn", new[]{"weernekers"} },
              { "Jumbo", null  },
              { "Vomar", null },
              { "MCD", null },
              { "Deen", null }
            } },
            { "Boodschappen", new Dictionary<string, string[]> {
              { "Kruidvat", null },
              { "Wibra", null },
              { "Hema", null },
              { "Primark", null },
              { "MS Mode", null },
              { "Bart Smit", null },
              { "Big L", null },
              { "Zeeman", null },
              { "Vogele", null },
              { "Primera", null },
              { "Knusz", null },
              { "Autoradam", null },
              { "Etos", null },
              { "Shell", null },
              { "Hallmark", null },
              { "Blokker", null },
              { "bol.com", null },
              { "The Read Shop", null }
            } },
            { "Bouwmarkt", new Dictionary<string, string[]> {
              { "Praxis", null },
              { "Gamma", null },
              { "Intratuin", null },
              { "Kwantum", null },
              { "Ikea", null }
            } },
            { "Eten", new Dictionary<string, string[]> {
              { "Lunch kantoor", new[]{"sodexo"} },
              { "Subway", null },
              { "Starbucks", null },
              { "Mariola", null },
              { "Bakker Bart", null },
              { "New York Pizza", null },
              { "Domino", null },
              { "Body & Fit", new[]{"fit sportsnutrition"} },
              { "Thuisbezorgd", null },
              { "Takeaway", null },
              { "Happie snack", null },
              { "Mc Donald's", null },
              { "Flevoziekenhuis", null },
            } },
            { "Parkeren", new Dictionary<string, string[]> {
              { "Parkeren", new[]{"parkeer", "garage", "parking", "hennepveld"} }
            } },
            { "Creditcard", new Dictionary<string, string[]> {
              { "Creditcard", null }
            } },
            { "Chipkaart", new Dictionary<string, string[]> {
              { "Chipkaart", null }
            } },
            { "Sparen", new Dictionary<string, string[]> {
              { "Sparen", new[]{"naar Bonusrenterekening"} }
            } },
            { "Recreatie", new Dictionary<string, string[]> {
              { "Efteling", null },
              { "Landal", new[]{"kraayenvanger groenlo"} },
              { "Travix", null },
              { "Hof van Saksen", null },
              { "Ballorig", null },
              { "Thermen", null },
              { "Marveld", null },
              { "Sprookjeswonderland", new[]{"sprookjeswonderlan"} }
            } },
            { "Online aankopen", new Dictionary<string, string[]> {
              { "Online aankopen", new[]{"pay.nl", "sisow", "omnikassa", "buckaroo", "globalcollect", "ingenico", "adyen", "mollie payments", "multisafepay", "docdata" } }
            } },
            { "Overig", new Dictionary<string, string[]> {
              { "Barbier Rogier", null },
              { "Bonjasky Academy", null },
            } },
        };

        var category = "UNKNOWN";

        foreach (var c in mappings)
        {
          foreach (var n in c.Value)
          {
            if (s[1].ToLower().Contains(n.Key.ToLower()) || (n.Value != null && n.Value.Any(v => s[1].ToLower().Contains(v.ToLower()))))
            {
              s[1] = n.Key;
              category = c.Key;

              break;
            }
          }
        }

        if (s[3] == string.Empty) s[3] = s[1];

        if (s[4].Trim() == "GM")
        {
          s[1] = "PIN";
          category = "PIN";
        }

        var fromAccount = manager.GetOrCreateAccount(s[2], s[1]);
        var toAccount = manager.GetOrCreateAccount(s[3], s[1], new List<string>(), category, AccountType.Other);

        manager.AddMutation(new Mutation
        {
          Date = DateTime.ParseExact(s[0], "yyyyMMdd", CultureInfo.InvariantCulture),
          Name = s[1].Trim(),
          FromAccount = fromAccount,
          ToAccount = toAccount,
          Code = s[4].Trim(),
          Quantity = Decimal.Parse(s[6], CultureInfo.GetCultureInfo("NL")) * (s[5] == "Af" ? -1 : 1),
          Type = s[7].Trim(),
          Remark = s[8].Trim()
        });
      }
    }
  }
}