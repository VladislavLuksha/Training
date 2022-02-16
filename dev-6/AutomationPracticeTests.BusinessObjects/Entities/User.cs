namespace AutomationPracticeTests.Entities
{
    public class User
    {
        public User(string userName, string password)
        {
            Email = userName;
            Password = password;
        }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string HomePhone { get; set; }
    }
}
