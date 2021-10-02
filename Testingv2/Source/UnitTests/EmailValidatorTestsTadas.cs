using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;
using ValidatorsUnitTests.Source.Validators;
using Xunit;

namespace Validation.Tests
{
    public class EmailValidatorTests
    {

        [Fact]
        public void EmailValidator_email_should_have_eta_symbol()
        {
            //Turi @ simbolį

            string email = "tadasdasd@gmail.com";

            var actual = EmailValidator.isEmailValid(email);

            Assert.True(actual, "Email does not contain @ symbol");
        }

        [Fact]
        public void EmailValidator_email_should_not_have_illegal_symbols()
        {
            //Neturi neleistinų simbolių
            string email = "tadasdasd@gmail.com";

            var actual = EmailValidator.isEmailValid(email);

            Assert.True(actual, "Email has illegal symbols");
        }

        [Fact]
        public void EmailValidator_email_should_have_correct_domain()
        {
            //Turi teisingą domeną
            string email = "tadasdasd@gmail.com";

            var actual = EmailValidator.isEmailValid(email);

            Assert.True(actual, "Email does not have the correct domain");
        }
        [Fact]
        public void EmailValidator_email_should_have_correct_TLD()
        {
            //Turi teisingą TLD
            string email = "tadasdasd@gmail.com";

            var actual = EmailValidator.isEmailValid(email);

            Assert.True(actual, "Email does not have the correct TLD");
        }
    }
}
