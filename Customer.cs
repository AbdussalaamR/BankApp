using System;
using System.Collections.Generic;
namespace StockManageApp
{
    public class Customer:Person
    {
        public string Fullname;
        public string AccountNum {get;set;}
        public AccountType accountType;
        public double AccountBalance = 0;
        private string Pin;
        private static int numberOfRegisterdCustomers = 0;
        public int NumberOfTransfer = 0;
         public static List<Customer> Customers = new List<Customer> ();
         public  List<string> TransferHistory  = new List<string> ();
         public bool accountActive = true;

        // public void AddCustomer()
        // {
        //     Customers.Add(this);
        // }
        
        public static void PrintCustomerList()
        {
            for (int i = 0; i < numberOfRegisterdCustomers; i++)
            {
              Console.WriteLine($"{i+1}. {Customers[i].FirstName} - {Customers[i].LastName} {Customers[i].AccountNum}");  
            }
        }

            public Customer(string firstName, string lastName, Gender sex, string email, string phone, string address, string accountNo, AccountType actType, int balance): base(firstName, lastName, sex, email, phone, address)
        {
            AccountNum = GenerateAcountNum();
        }
        public Customer(string accountNum, bool accountActiv)
        {
            AccountNum = accountNum;
            accountActive = accountActiv;
        }
            public Customer( string beneficiaryBankName, string beneficiaryAcctNo, double amount)
            {

            }
            public Customer(string firstName, string lastName, Gender sex, string email, string phone, string address, AccountType actType, string pin): base(firstName, lastName, sex, email, phone, address)
        {
            Pin = pin;
            AccountNum = GenerateAcountNum();
        }
            public Customer()
            {
                
            }
            public Customer(string firstName, string lastName, string acctNo)
            {
                FirstName = firstName;
                LastName = lastName;
                AccountNum =acctNo;
            }
        public Customer(string fullname, AccountType acctType, string accountNum, int acctBalance)
        {
            Fullname = GetFullName();
            accountType =  acctType;
            AccountNum = GenerateAcountNum();
            AccountBalance = acctBalance;
        }

        public static string GenerateAcountNum()
        {
            Random acctNum = new Random();
            string acctNo1 = acctNum.Next(1000, 5000).ToString();
            string acctNo2 = acctNum.Next(6000, 9000).ToString();
            string acctNo3 = acctNum.Next(10, 99).ToString();
            string acctNo = $"{acctNo1}{acctNo2}{acctNo3}";
            return acctNo;
        }
        public static Customer CustomerReg()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Welcome! Thanks for choosing XYZ Bankank, please fill the form below to register.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Gender (Enter 1 for male and 2 for female): ");
            int sex = int.Parse(Console.ReadLine());
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Phone number: ");
            string phoneNum = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("What type of account do you wish to open? (Enter 1 for Savings and 2 for Current)");
            int actType = int.Parse(Console.ReadLine());
            Console.Write("Enter a four digit pin (digits should be between 0 - 9 and personal to you ): ");
            string pin = Console.ReadLine();
            Customer customer = new Customer(firstName, lastName, (Gender)sex, email, phoneNum,  address, (AccountType)actType, pin);
            Customers.Add(customer);
            numberOfRegisterdCustomers++;
            return customer;
        }
        public static Customer GetAccountDetailsAndPin()
        {
            Console.Write("Enter your Account Number: ");
            string accountNum = Console.ReadLine();
            Console.Write("Enter your Pin: ");
            string pin = Console.ReadLine();
            foreach (var customer in Customers)
            {
                if (accountNum == customer.AccountNum && pin == customer.Pin && customer.accountActive == true)
                {
                   return customer;
                }
                 

            }
            return null;
        }

        public static Customer ConfirmCustomer(string actNo)
        {
            foreach (var customer in Customers)
            {
                if (actNo == customer.AccountNum)
                {
                   return customer;
                }
                 

            }
            return null;
        }

        public void PrintTransferHistory()
        {
            Customer customer = Customer.GetAccountDetailsAndPin();
            if (customer != null)
            {
              foreach (var history in customer.TransferHistory)
              {
                Console.WriteLine(history);  
              }  
            }
        }
        public static void Transfer()
        {
            Customer customer = Customer.GetAccountDetailsAndPin();
            if (customer != null)
            {
                Console.Write("Enter Beneficiary's bank: ");
                string beneficiaryBankName = Console.ReadLine();
                Console.Write("Enter Beneficiary's account number: ");
                string beneficiaryAcctNo = Console.ReadLine();
                Customer actHolder = ConfirmCustomer(beneficiaryAcctNo);
                    if (actHolder != null)
                        {
                        Console.Write("Enter amount (Note that you will be charged a service fee of 0.2% of amount): ");
                        double amount = double.Parse(Console.ReadLine());
                        Console.WriteLine($"You want to transfer {amount} to {actHolder.Fullname}");
                        Console.Write("Enter Pin to confirm: ");
                        string pin = Console.ReadLine();
                        double transferCharges = amount * 0.002;
                        double debit = amount +  transferCharges;
                        if (pin == customer.Pin)
                            {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine ($"Your transaction is being processed.\n" + $"Your account balance is {(customer.AccountBalance - debit)}");
                            customer.AccountBalance -= debit;
                            Console.ForegroundColor = ConsoleColor.White;
                            string history = $"{DateTime.Now}   {beneficiaryBankName}    {beneficiaryAcctNo}    {amount}";
                            string beneficiaryhistory = $"{DateTime.Now}   {customer.Fullname}    {customer.AccountNum}    {amount}";
                            customer.TransferHistory.Add(history);
                            actHolder.TransferHistory.Add(beneficiaryhistory);
                            actHolder.AccountBalance += amount;
                            customer.NumberOfTransfer++;
                            }
                    }
                    else
                    {
                        Console.WriteLine("Beneficiary account not found");
                    }   
            } 
              else
            {
                Console.WriteLine($"No matches found! Try again or Register to open an accout.");
            }
            
        }

        public static void Withdraw ()
        {
            Customer customer = Customer.GetAccountDetailsAndPin();
            if (customer != null)
            {
                Console.Write("Re-enter Pin: ");
                string pin = Console.ReadLine();
                Console.Write("Enter amount: ");
                double amount = double.Parse(Console.ReadLine()); 
                    if (pin == customer.Pin)
                    {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine ($"Take your money\n" + $"Your account balance is {(customer.AccountBalance - amount)}");
                        customer.AccountBalance -= amount;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
            }
            else
            {
                Console.WriteLine($"No matches found! Try again or Register to open an accout.");
            }    
        }

        public static void Deposit()
        {
            Customer customer = Customer.GetAccountDetailsAndPin();
            if (customer != null)
            {
                Console.Write("Enter amount you want to deposit: ");
                double amountDeposit = double.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine ($"Transaction successful\n" + $"Your account balance is {(customer.AccountBalance + amountDeposit)}");
                customer.AccountBalance += amountDeposit;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine($"No matches found! Try again or Register to open an accout.");
            }
        }
        public static void CheckBalance()
        {
            Customer customer = Customer.GetAccountDetailsAndPin();
            if (customer != null)
            {
                Console.WriteLine($"Your accout balance is {customer.AccountBalance}");
            }
            else
            {
                Console.WriteLine($"No matches found! Try again or Register to open an accout.");
            }
        }
    }
}