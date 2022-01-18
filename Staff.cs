using System;
using System.Collections.Generic;
namespace StockManageApp
{
    public class Staff:Person
    {
        public string StaffID {get;}
        private string PassWord {get; set;}
        private static int numberOfRegisterdStaff = 0;
        private static List<Staff> Staf = new List<Staff> ();


        public Staff(string firstName, string lastName, Gender sex, string email, string phone, string address, string staffID): base(firstName, lastName, sex, email, phone, address)
        {
            StaffID = GenerateStaffID();
        }
        public Staff(string firstName, string lastName, Gender sex, string email, string phone, string address, string staffId, string password): base(firstName, lastName, sex, email, phone, address)
        {
            PassWord = password;
        }

        public string GenerateStaffID()
        {
            return $"SD{(numberOfRegisterdStaff + 1).ToString("000")}";
        }
        public static bool ConfirmStaff(string id, string passWord)
        {
            foreach (var staff in Staf)
            {
                if (id == staff.StaffID && passWord == staff.PassWord)
                {
                   return true;
                }
                 

            }
            return false;
        }
        public static void DeactivateAcct()
        {
          Console.Write("Enter Staff ID: ");
          string staffId = Console.ReadLine();
          Console.Write("Enter password: ");
          string passWord = Console.ReadLine();
          bool isStaff = ConfirmStaff(staffId, passWord);
          if (isStaff == true)
          {
            Console.Write("Enter customer's account number: ");
            string accountNum = Console.ReadLine();
            foreach (var customer in Customer.Customers)
            {
                if (customer.AccountNum == accountNum)
                {
                    customer.accountActive = false;
                        Console.WriteLine("Account has been deactivated");
                        return;
                }
            }
                Console.WriteLine("Account number not found");
          }
          else
          {
              Console.WriteLine("Sorry! You do not have access to perform this operation.");
          }
        }
        public static Staff StaffReg()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome!");
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
            Console.Write("Enter password (not longer than 8 characters and should contain at least one uppercase alphabet and any of *, #, @, $ ): ");
            string password = Console.ReadLine();
            Staff staf = new Staff (firstName, lastName, (Gender)sex, email, phoneNum,  address, password);
            Staf.Add(staf);
            numberOfRegisterdStaff++;
            return staf;
        }
    }
}