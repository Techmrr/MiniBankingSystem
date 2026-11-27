
public class SavingsAccount : BankAccount
{
    public decimal InterestRate { get; private set; }

    public SavingsAccount(
        string ownerName,
        decimal balance,
        decimal interestRate
    ) : base(ownerName, balance)
    {
        if (interestRate < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(interestRate),
                "Interest rate cannot be negative."
            );
        }

        InterestRate = interestRate;
    }

    public override decimal CalculateInterest()
    {
        return Balance * InterestRate / 100m;
    }
}
