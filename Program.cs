using System.Reflection.Metadata.Ecma335;

bool isRunning = true;

List<BankAccount> accounts = new List<BankAccount>();

// Add three bank accounts
accounts.Add(new BankAccount("Ali", 1500m));
accounts.Add(new BankAccount("Sara", 3200m));
accounts.Add(new BankAccount("Reza", 5000m));

// Print all accounts using foreach
foreach (BankAccount account in accounts)
{
    Console.WriteLine($"Owner: {account.OwnerName}, Balance: ${account.Balance:F2}");
}

while (isRunning)
{
    Console.WriteLine("Welcome to Mini Banking System!");
    Console.WriteLine("1. Create Account");
    Console.WriteLine("2. Check Balance");
    Console.WriteLine("3. Deposit Money");
    Console.WriteLine("4. Withdraw Money");
    Console.WriteLine("5. Exit");

    Console.Write("Select an option: ");
    string? choice = Console.ReadLine();
    Console.WriteLine($"You selected option {choice}");

    if (choice == "1")
    {
        Console.Write("Enter owner name: ");
        string? ownerName = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(ownerName))
        {
            Console.Write("Enter initial balance: ");
            string? input = Console.ReadLine();

            if (decimal.TryParse(input, out decimal initialBalance))
            {
                if (initialBalance >= 0)
                {
                    accounts.Add(new BankAccount(ownerName, initialBalance));

                    Console.WriteLine("Account created successfully!");
                    Console.WriteLine($"Owner: {ownerName}, Balance: ${initialBalance:F2}");
                }
                else
                {
                    Console.WriteLine("Initial balance cannot be negative!");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount!");
            }
        }
        else
        {
            Console.WriteLine("Invalid owner name!");
        }
    }

    else if (choice == "2")
    {
        BankAccount? selectedAccount = SelectAccount(accounts);

        if (selectedAccount != null)
        {
            ShowBalance(selectedAccount.Balance);
        }
        else
        {
            Console.WriteLine("Invalid account!");
        }
    }
    else if (choice == "3")
    {
        BankAccount? selectedAccount = SelectAccount(accounts);

        if (selectedAccount != null)
        {
            Console.Write("Enter deposit amount: ");
            string? input = Console.ReadLine();

            if (decimal.TryParse(input, out decimal amount))
            {
                if (selectedAccount.Deposit(amount))
                {
                    Console.WriteLine("Deposit successful!");
                    Console.WriteLine($"New balance: ${selectedAccount.Balance:F2}");

                }
                else
                {
                    Console.WriteLine("Deposit failed!");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount!");
            }
        }
        else
        {
            Console.WriteLine("Invalid account!");
        }
    }
    else if (choice == "4")
    {
        BankAccount? selectedAccount = SelectAccount(accounts);

        if (selectedAccount != null)
        {
            Console.Write("Enter withdraw amount: ");
            string? input = Console.ReadLine();

            if (decimal.TryParse(input, out decimal amount))
            {
                if (selectedAccount.Withdraw(amount))
                {
                    Console.WriteLine("Withdrawal successful!");
                    Console.WriteLine($"New balance: ${selectedAccount.Balance:F2}");
                }
                else
                {
                    Console.WriteLine("Withdrawal failed!");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount!");
            }
        }
        else
        {
            Console.WriteLine("Invalid account!");
        }
    }
    else if (choice == "5")
    {
        Console.WriteLine("Goodbye!");
        isRunning = false;
    }
    else
    {
        Console.WriteLine("Invalid option. Please try again.");
    }
}

static void ShowBalance(decimal balance)
{
    Console.WriteLine($"Your current balance is ${balance:F2}");
}

static BankAccount? SelectAccount(List<BankAccount> accounts)
{
    Console.WriteLine("Select an account:");
    for (int i = 0; i < accounts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {accounts[i].OwnerName}");
    }

    Console.Write("Enter account number: ");
    string? choice = Console.ReadLine();
    if (int.TryParse(choice, out int accountNumber) && accountNumber >= 1 && accountNumber <= accounts.Count)
    {
        return accounts[accountNumber-1];
    }
    else 
    {
        return null;
    }
}