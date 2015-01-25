using System;

namespace BigSpender.Objects
{
  public class Mutation
  {
    private Account _fromAccount;
    private Account _toAccount;

    public DateTime Date;
    public string Name;
    public string Code;
    public decimal Quantity;
    public string Type;
    public string Remark;

    public Account FromAccount
    {
      get { return _fromAccount; }
      set
      {
        value.Mutations.Add(this);
        _fromAccount = value;
      }
    }

    public Account ToAccount
    {
      get { return _toAccount; }
      set
      {
        value.Mutations.Add(this);
        _toAccount = value;
      }
    }
  }
}