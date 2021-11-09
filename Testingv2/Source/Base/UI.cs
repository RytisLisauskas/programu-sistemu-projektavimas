using System;
namespace ValidatorsUnitTests.Source.Base
{
    public  class UI
    {
        UserService _userService = new UserService();

        public void FetchData() {
            _userService.LoadUserList();
        }

        public void SendData()
        {
            _userService.SaveUserList();
        }

        private  void printMenu(string type) {
            if (type == "entry")
            {
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. See existing users");
                Console.WriteLine("3. Delete user");
                Console.WriteLine("4. Edit user");
                Console.WriteLine("0. Quit");
            }
        }

        public  void StartMenu() {
            string entry = "11";
            while (entry != "0") {
                printMenu("entry");
                entry = Console.ReadLine();
                if (entry == "1") {
                    _userService.CreateUser(AskForData());
                }
                if (entry == "2") {
                    _userService.PrintUsers();
                }
                if (entry == "3")
                {
                    _userService.PrintUsers();
                    string name = AskForName();
                    _userService.DeleteUser(name);
                }
                if (entry == "4")
                {
                    _userService.PrintUsers();
                    string name = AskForName();
                    _userService.EditUser(name,AskForData());
                }
                if (entry == "0") {
                    break;
                }
            }
        }

        public string[] AskForData() {
            string name = AskForName();
            Console.WriteLine("Surname:");
            string surname = Console.ReadLine();
            Console.WriteLine("Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Password:");
            string password = Console.ReadLine();
            Console.WriteLine("Address:");
            string address = Console.ReadLine();
            Console.WriteLine("Phone number:");
            string number = Console.ReadLine();

            string[] fields = { name, surname, email, password, address, number };
            return fields;
        }

        private string AskForName() {
            Console.WriteLine("Name:");
            return Console.ReadLine();
        }   
    }
}
