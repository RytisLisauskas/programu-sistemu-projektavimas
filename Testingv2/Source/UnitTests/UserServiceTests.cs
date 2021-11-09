using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidatorsUnitTests.Source.Base;

namespace ValidatorsUnitTests.Source.UnitTests
{
    [TestClass]
    public class UserServiceTests
    {
        UserService _service = new UserService() { };

        [TestMethod]
        public void Bad_mail_user_should_not_add()
        {
            string[] fields = { "mano", "useris", "mail", "ManoGrybasBaravykas_56", "laukine gatve", "864777262" };
            var response = _service.CreateUser(fields);
            Assert.IsFalse(response, "Bad email");
        }

        [TestMethod]
        public void Bad_password_user_should_not_add()
        {
            string[] fields = { "kitas", "useris", "asdasff@gmail.com", "a", "laukine gatve", "864777262" };
            var response = _service.CreateUser(fields);
            Assert.IsFalse(response, "Bad password");
        }

        [TestMethod]
        public void Bad_number_user_should_not_add()
        {
            string[] fields = { "darkitas", "useris", "asdasff@gmail.com", "a", "laukine gatve", "123a123" };
            var response = _service.CreateUser(fields);
            Assert.IsFalse(response, "Number");
        }

        [TestMethod]
        public void Non_existing_user_should_not_edit()
        {
            string[] fields = { "baubekas", "pavarde", "asdasff@gmail.com", "a", "laukine gatve", "123a123" };
            var response = _service.EditUser("baubekas",fields);
            Assert.IsFalse(response, "Non existing user");
        }


        [TestMethod]
        public void Existing_user_invalid_data()
        {
            string[] fields = { "kitas", "pavarde", "asdasff@gmail.com", "a", "laukine gatve", "123a123" };
            var response = _service.EditUser("kitas", fields);
            Assert.IsFalse(response, "invalid data on user");
        }
    }
}
