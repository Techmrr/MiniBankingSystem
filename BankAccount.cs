public abstract class BankAccount : IAccountOperations
{
    public string OwnerName { get; private set; }
    public decimal Balance { get; private set; }

public BankAccount(string ownerName, decimal balance)
{
    if (string.IsNullOrWhiteSpace(ownerName))
    {
        throw new ArgumentException(
            "Owner name cannot be empty.",
            nameof(ownerName)
        );
    }

    if (balance < 0)
    {
        throw new ArgumentOutOfRangeException(
            nameof(balance),
            "Initial balance cannot be negative."
        );
    }

    OwnerName = ownerName;
    Balance = balance;
}
    public bool Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            return true;
        }
        return false;
    }
    public bool Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }
    public abstract decimal CalculateInterest();
}