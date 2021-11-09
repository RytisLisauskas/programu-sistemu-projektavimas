using System;
using System.Collections.Generic;
using System.Linq;
using ValidatorsUnitTests.Source.Base.Entities;
using ValidatorsUnitTests.Source.Base.Repository;
using ValidatorsUnitTests.Source.Base.Services;

namespace ValidatorsUnitTests.Source.Base
{
    public class UserService : IUserService
    {
        UserRepository _repo = new UserRepository();
        Validator _validator = new Validator();
        List<User> users = new List<User>();


        public bool SaveUserList() {
            if (users != null)
            {
                bool response = _repo.SaveAll(users.ToArray());
                return response;
            }
            else return false;
        }

        public bool LoadUserList() {
            users = _repo.LoadAll().ToList();
            if (users == null) {
                return false;
            }
            return true;
        }

        public bool CreateUser(string[] fields)
        {
            User user = new User(fields[0],fields[1],fields[2],fields[5],fields[3],fields[4]);
            if (_validator.ValidateEmail(user.Email) && _validator.ValidatePassword(user.Password))
            {
                if (_validator.ValidateNumber(user.PhoneNumber) != "")
                {
                    User check = users.FirstOrDefault(x => x.Name == user.Name);
                    if (check != null) {
                        Console.WriteLine("User already exists");
                        return false;
                    }
                    users.Add(user);
                    return true;
                }
                else return false;
            }
            else return false;
        }

        public bool DeleteUser(string name)
        {
            User user = users.FirstOrDefault(x => x.Name == name);
            if (user != null)
            {
                users.Remove(user);
                return true;
            }
            else {
                Console.WriteLine("User could not be found");
                return false;
            }
        }

        public bool EditUser(string name, string[] fields)
        {
            User user = users.FirstOrDefault(x => x.Name == name);
            if (user != null)
            {
                    users.Remove(user);
                    this.CreateUser(fields);
                    return true;
            }
            return false;
        }

        public void PrintUsers() {
            foreach (User user in users) {
                Console.WriteLine(user.ToString());
            }
        }

    }
}
