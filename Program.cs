using System;
using SimpleBankingApplication.Services;
AccountService accountService = new AccountService();

BankService bankService = new BankService();

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("=== Simple Banking Application ===");

while (true)
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("=== Menu ===");

    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("1. ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Register");

    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("2. ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Login");

    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("3. ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Exit");

    Console.Write("Enter your choice: ");
    switch (Console.ReadLine())
    {
        case "1":
            Register(accountService);
            break;
        case "2":
            string userName;
            if (Login(accountService, out userName))
            {
                Console.WriteLine("Login successfully.....");
                Console.WriteLine("Welcome to Banking System");

                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("=== Menu ===");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("1. ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Deposit");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("2. ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Withdraw");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("3. ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Print Passbook");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("4. ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Check Balance");

                    Console.Write("Enter your choice: ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Deposit(bankService, userName);
                            break;
                        case "2":
                            break;
                        case "3":
                            break;
                        case "4":
                            break;
                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }
            }
            break;
        case "3":
            Console.WriteLine("Good Bye!");
            return;
        default:
            Console.WriteLine("Invalid option, please select again.");
            break;
    }
    



}
void Register(AccountService accountService)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("\n=== Register new Customer ====");

    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("\nEnter the First name: ");
    string firstName = Console.ReadLine()!;


    Console.Write("\nEnter the Second name: ");
    string secondName = Console.ReadLine()!;

    Console.Write("\nEnter the date of birth(YYYY-MM-DD): ");
    if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
    {
        Console.Write("\nEnter the Address: ");
        string address = Console.ReadLine()!;

        Console.Write("\nEnter the Phone number: ");
        string phoneNumber = Console.ReadLine()!;

        Console.Write("\nEnter the Gender(Male/Female/Other): ");
        string gender = Console.ReadLine()!;

        Console.Write("\nEnter the Account type(savings/current): ");
        string accType = Console.ReadLine()!;
        accountService.CreateNewCustomer(firstName, secondName, date, address, phoneNumber, gender, accType);
    }
    else
    {
        Console.WriteLine("Invalid data format, please try again!");
    }

}

bool Login(AccountService accountService, out string user)
{
    user = "0";
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("\n=== Login ====");

    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("\nEnter the User Name: ");
    string userName = Console.ReadLine()!;
    user = userName;
    Console.WriteLine("\nEnter the password: ");
    string password = Console.ReadLine()!;

    return accountService.GetCustomer(userName, password);

}

void Deposit(BankService bankService, string userName)
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("=== Deposit ===");

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("\nEnter the amount: ");
    if (decimal.TryParse(Console.ReadLine(), out decimal amount))
    {
        bankService.DepositAmount(userName, amount);
    }
    else
    {
        Console.WriteLine("Invalid amount, please try again!");
    }
}

