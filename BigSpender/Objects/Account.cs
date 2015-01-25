using System.Collections.Generic;

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

    public Account()
    {
      OtherNumbers = new List<string>();
      Mutations = new List<Mutation>();
    }
  }
}