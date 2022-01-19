using System;

namespace StockManageApp
{
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("*****Welcome to XYZ Bank, your partner in wealth generation!*****");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("1. Open an account");
            Console.WriteLine("2. Register as Staff");
            Console.WriteLine("3. List of Customers");
            Console.WriteLine("4. Deposit");
            Console.WriteLine("5. Withdraw");
            Console.WriteLine("6. Transfer");
            Console.WriteLine("7. Deactivate Account");
            Console.WriteLine("8. View Transfer History");
            Console.WriteLine("9. Check account balance");
            string entry = Console.ReadLine();
            
            switch (entry)
            {
                case "1":
                Customer customer = Customer.CustomerReg();
                customer.AccountNum= Customer.GenerateAcountNum();
                Console.WriteLine($"Account opened successfully! Your acount number is {customer.AccountNum}");
                Main();
                break;
                case "2":
                Staff staf = Staff.StaffReg();
                Console.WriteLine($"Your account has been created succesfully! Your staff ID is {staf.StaffID}");
                Main();
                break;
                case "3":
                Customer.PrintCustomerList();
                Main();
                break;
                case "4":
                Customer.Deposit();
                Main();
                break;
                case "5":
                Customer.Withdraw();
                Main();
                break;
                case "6":
                Customer.Transfer();
                Main();
                break;
                case "7":
                Staff.DeactivateAcct();
                Main();
                break;
                case "8":
                Customer customer1 = new Customer();
                customer1.PrintTransferHistory();
                Main();
                break;
                case "9":
                Customer.CheckBalance();
                Main();
                break;
                default:
                Console.WriteLine("Invalid input! Enter the correct option that matches what you want to do");
                Main();
                break;
            }

        }
    }
}
