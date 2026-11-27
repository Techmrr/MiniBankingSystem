
public class CheckingAccount : BankAccount
{
    public CheckingAccount(string ownerName, decimal balance)
        : base(ownerName, balance)
    {
    }

    public override decimal CalculateInterest()
    {
        return 0m;
    }
}
