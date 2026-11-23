decimal balance = 1000.00m;
bool isRunning = true;

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
    Console.WriteLine("Creating a new bank account...");
}
else if (choice == "2")
{
    Console.WriteLine($"Your current balance is ${balance:F2}");
}
else if (choice == "3")
{
    Console.Write("Enter deposit amount: ");
    string? input = Console.ReadLine();

    if (decimal.TryParse(input, out decimal amount))
    {
        if (amount>0)
        {
            balance += amount;
            Console.WriteLine("Deposit successful!");
            Console.WriteLine($"Your current balance is ${balance:F2}");
        }
        else
        {
            Console.WriteLine("Deposit must be greater than zero!");            
        }
    }
    else
    {
        Console.WriteLine("Invalid amount!");
    }
}
else if (choice == "4")
{
    Console.Write("Enter withdraw amount: ");
    string? input = Console.ReadLine();

    if (decimal.TryParse(input, out decimal amount))
    {
        if (amount<=balance && amount>0)
        {
            balance -= amount;
            Console.WriteLine("Withdraw successful!");
            Console.WriteLine($"Your current balance is ${balance:F2}");
        }
        else if(amount>balance)
        {
            Console.WriteLine("Insufficient funds!");            
        }
        else
        {
            Console.WriteLine("Invalid amount!");            
        }
    }
    else
    {
        Console.WriteLine("Invalid amount!");
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