using System;
namespace ValidatorsUnitTests.Source.Base.Services
{
    public interface IUserService
    {
        public bool CreateUser(string[] fields);
        public bool EditUser(string name, string[] fields);
        public bool DeleteUser(string name);
    }
}
