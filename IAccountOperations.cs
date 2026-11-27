public interface IAccountOperations
{
    bool Deposit(decimal amount);

    bool Withdraw(decimal amount);
}