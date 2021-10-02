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
    public class PhoneValidatorTests
    {

        [Fact]
        public void PhoneValidator_Number_should_contain_only_digits()
        {
            //Nėra kitų simbolių nei skaičių

            string phoneNumber = "+37067318261";
            int numberLength = 8;
            string phoneNumberPrefix = "+370";


            var actual = PhoneNumberValidator.IsPhoneNumberValid(phoneNumber);


            Assert.True(actual, "Phone number is not valid.Should contain only digits");

        }
        [Fact]
        public void PhoneValidator_Starting_with_number_eight_should_change_to_lithuanian_phone_code()
        {
            //Jei prasideda su 8, tai pakeičia į +370

            string phoneNumber = "+37067318261";
            int numberLength = 8;
            string phoneNumberPrefix = "+370";


            var actual = PhoneNumberValidator.IsPhoneNumberValid(phoneNumber);


            Assert.True(actual, "Phone number is not valid. Wrong lithuanian format");

        }
        [Fact]
        public void PhoneValidator_number_lenght_is_correct_depending_on_country()
        {
            //Yra galimybė pridėti naujų validavimo taisyklių pagal šalį(ilgis ir prefiksas)

            string phoneNumber = "+37067318261";
            int numberLength = 8;
            string phoneNumberPrefix = "+370";


            var actual = PhoneNumberValidator.IsPhoneNumberValid(phoneNumber);


            Assert.True(actual, "Phone number is not valid. Incorrect ");

        }

        [Fact]
        public void PhoneValidator_number_prefix_is_correct_depending_on_country()
        {
            //Yra galimybė pridėti naujų validavimo taisyklių pagal šalį(ilgis ir prefiksas)

            string phoneNumber = "+37067318261";
            int numberLength = 8;
            string phoneNumberPrefix = "+370";


            var actual = PhoneNumberValidator.IsPhoneNumberValid(phoneNumber);


            Assert.True(actual, "Phone number is not valid. Incorrect country prefix and/or length");

        }
    }
}
