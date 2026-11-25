public class BankAccount
{
    public string OwnerName { get; private set; }
    public decimal Balance { get; private set; }

    public BankAccount(string ownerName, decimal balance)
    {
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
}