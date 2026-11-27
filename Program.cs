bool isRunning = true;

// Initialize bank accounts
List<BankAccount> accounts = new List<BankAccount>
{
    new CheckingAccount("Ali", 1500m),
    new CheckingAccount("Sara", 3200m),
    new CheckingAccount("Reza", 5000m),
    new SavingsAccount("Mina", 1000m, 5m)
};

// Main application loop
while (isRunning)
{
    Console.WriteLine();
    Console.WriteLine("===== MINI BANKING SYSTEM =====");
    Console.WriteLine("1. Create Account");
    Console.WriteLine("2. Check Balance");
    Console.WriteLine("3. Deposit Money");
    Console.WriteLine("4. Withdraw Money");
    Console.WriteLine("5. Bank Report");
    Console.WriteLine("6. Exit");
    Console.WriteLine("===============================");

    Console.Write("Select an option: ");
    string? choice = Console.ReadLine();

    if (choice == null)
    {
        break;
    }

    Console.WriteLine();

    switch (choice)
    {
        case "1":
            CreateAccount(accounts);
            break;

        case "2":
            CheckBalance(accounts);
            break;

        case "3":
            DepositMoney(accounts);
            break;

        case "4":
            WithdrawMoney(accounts);
            break;

        case "5":
            ShowBankReport(accounts);
            break;

        case "6":
            Console.WriteLine("Goodbye!");
            isRunning = false;
            break;

        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}

// Create a new checking account
static void CreateAccount(List<BankAccount> accounts)
{
    Console.Write("Enter owner name: ");
    string? ownerName = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(ownerName))
    {
        Console.WriteLine("Invalid owner name!");
        return;
    }

    Console.Write("Enter initial balance: ");
    string? input = Console.ReadLine();

    if (!decimal.TryParse(input, out decimal initialBalance))
    {
        Console.WriteLine("Invalid amount!");
        return;
    }

    try
    {
        BankAccount newAccount =
            new CheckingAccount(ownerName, initialBalance);

        accounts.Add(newAccount);

        Console.WriteLine("Account created successfully!");
        Console.WriteLine($"Owner: {newAccount.OwnerName}");
        ShowBalance(newAccount.Balance);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

// Select an account from the list
static BankAccount? SelectAccount(List<BankAccount> accounts)
{
    if (accounts.Count == 0)
    {
        Console.WriteLine("No accounts available!");
        return null;
    }

    Console.WriteLine("Select an account:");

    for (int i = 0; i < accounts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {accounts[i].OwnerName}");
    }

    Console.Write("Enter account number: ");
    string? input = Console.ReadLine();

    if (int.TryParse(input, out int accountNumber)
        && accountNumber >= 1
        && accountNumber <= accounts.Count)
    {
        return accounts[accountNumber - 1];
    }

    return null;
}

// Check the balance of a selected account
static void CheckBalance(List<BankAccount> accounts)
{
    BankAccount? account = SelectAccount(accounts);

    if (account == null)
    {
        Console.WriteLine("Invalid account!");
        return;
    }

    Console.WriteLine($"Owner: {account.OwnerName}");
    ShowBalance(account.Balance);
}

// Display account balance
static void ShowBalance(decimal balance)
{
    Console.WriteLine($"Current balance: ${balance:F2}");
}

// Deposit money into a selected account
static void DepositMoney(List<BankAccount> accounts)
{
    BankAccount? account = SelectAccount(accounts);

    if (account == null)
    {
        Console.WriteLine("Invalid account!");
        return;
    }

    Console.Write("Enter deposit amount: ");
    string? input = Console.ReadLine();

    if (!decimal.TryParse(input, out decimal amount))
    {
        Console.WriteLine("Invalid amount!");
        return;
    }

    if (account.Deposit(amount))
    {
        Console.WriteLine("Deposit successful!");
        ShowBalance(account.Balance);
    }
    else
    {
        Console.WriteLine("Deposit failed! Amount must be positive.");
    }
}

// Withdraw money from a selected account
static void WithdrawMoney(List<BankAccount> accounts)
{
    BankAccount? account = SelectAccount(accounts);

    if (account == null)
    {
        Console.WriteLine("Invalid account!");
        return;
    }

    Console.Write("Enter withdrawal amount: ");
    string? input = Console.ReadLine();

    if (!decimal.TryParse(input, out decimal amount))
    {
        Console.WriteLine("Invalid amount!");
        return;
    }

    if (account.Withdraw(amount))
    {
        Console.WriteLine("Withdrawal successful!");
        ShowBalance(account.Balance);
    }
    else
    {
        Console.WriteLine("Withdrawal failed! Check amount and balance.");
    }
}

// Generate a summary report for all accounts
static void ShowBankReport(List<BankAccount> accounts)
{
    if (accounts.Count == 0)
    {
        Console.WriteLine("No accounts available!");
        return;
    }

    int totalAccounts = accounts.Count;
    decimal totalBalance = accounts.Sum(a => a.Balance);
    decimal averageBalance = accounts.Average(a => a.Balance);

    Console.WriteLine("===== BANK REPORT =====");
    Console.WriteLine($"Total accounts: {totalAccounts}");
    Console.WriteLine($"Total balance: ${totalBalance:F2}");
    Console.WriteLine($"Average balance: ${averageBalance:F2}");

    Console.WriteLine();
    Console.WriteLine("Account Details:");

    foreach (BankAccount account in accounts)
    {
        Console.WriteLine(
            $"Owner: {account.OwnerName}, " +
            $"Balance: ${account.Balance:F2}, " +
            $"Interest: ${account.CalculateInterest():F2}"
        );
    }
}
