using System;
namespace ValidatorsUnitTests.Source.Base
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public User(string name, string surname, string email, string number, string password, string address) {
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.PhoneNumber = number;
            this.Password = password;
            this.Address = address;
        }

        public override string ToString()
        {
            return Name + " " + Surname + " " + Email + " " + PhoneNumber + " " + Password + " " + Address; 
        }
    }
}
