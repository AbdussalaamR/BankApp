namespace StockManageApp
{
    public abstract class  Person
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Address {get; set;}         public string PhoneNum {get; set;}
        public string Email {get; set;}
        public Gender Sex;
       public Person(string firstName, string lastName, Gender sex, string address, string email, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNum = phone;
            Address = address;
            Sex = sex;
            
        }
        public Person()
        {
            
        }
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        } 
         public string GetContactDetails()
        {
            return $"{Address}\t" + "{Email}\t" + "{PhoneNum}";
        }
        public string GetDetails()
        {
            return $"(GetFullName())\n" + GetContactDetails();
        }
    }
}