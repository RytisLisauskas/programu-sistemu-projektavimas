using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidatorsUnitTests;
using Xunit;

namespace Validation.Tests
{
    public class PasswordValidatorTests
    {

        [Fact]
        public void PasswordChecker_Password_should_be_longer_than_given_number()
        {
            // Tikrina ar slaptažodžio ilgis netrumpesnis nei X

            string passwordToTest = "SveikiVisi1@";

            var actual = PasswordValidator.IsPasswordValid(passwordToTest);

            Assert.True(actual , "Password is not suitable because it is too short");
        }

        [Fact]
        public void PasswordChecker_Password_should_have_uppercase_letters()
        {
            //Tikrina ar yra Uppercase simbolių

            string passwordToTest = "SveikiVisi1@";

            var actual = PasswordValidator.IsPasswordValid(passwordToTest);

            Assert.True(actual, "Password is not suitable because there is no uppercase letters");
        }

        [Fact]
        public void PasswordChecker_Password_should_have_special_symbols()
        {
            //Tikrina ar yra specialus simbolis(specialių simbolių sąrašas turi būti konfiguruojamas)

            string passwordToTest = "SveikiVisi1@";

            var actual = PasswordValidator.IsPasswordValid(passwordToTest);

            Assert.True(actual, "Password does not contain special letters");
        }


    }
}
