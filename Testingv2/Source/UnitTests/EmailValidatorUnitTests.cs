using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidatorsUnitTests.Source.Validators;

namespace ValidatorsUnitTests
{
    [TestClass]
    public class EmailValidatorUnitTests
    {
        [TestMethod]
        public void Email_is_blank_spaces_should_not_be_valid()
        {
            var isValid = EmailValidator.isEmailValid("   ");
            Assert.AreEqual(false, isValid, "Not a valid email because its empty spaces only and is too short.");
        }

        [TestMethod]
        public void Email_is_too_short_should_not_be_valid()
        {
            var isValid = EmailValidator.isEmailValid("a");
            Assert.AreEqual(false, isValid, "Not a valid email because its too short.");
        }

        [TestMethod]
        public void Email_does_not_have_at_sign_not_valid()
        {
            var isValid = EmailValidator.isEmailValid("lisauskas.rytisgmail.com");
            Assert.AreEqual(false, isValid, "Not a valid email because it does not have @ sign.");
        }

        [TestMethod]
        public void Email_have_spaces_not_valid()
        {
            var isValid = EmailValidator.isEmailValid("lisa uskas.rytis gmail.com");
            Assert.AreEqual(false, isValid, "Not a valid email because it has spaces.");
        }

        [TestMethod]
        public void Email_does_not_have_dot_in_domain()
        {
            var isValid = EmailValidator.isEmailValid("lisauskas.rytis@gmailcom");
            Assert.AreEqual(false, isValid, "Not a valid email, no dot in domain.");
        }

        [TestMethod]
        public void Email_has_a_dot_before_at_sign_not_valid()
        {
            var isValid = EmailValidator.isEmailValid("lisauskas.rytis.@gmail.com");
            Assert.AreEqual(false, isValid, "Not a valid email, dot before @");
        }

        //visiskai validus domain.
        [TestMethod]
        public void Email_has_valid_domain()
        {
            var isValid = EmailValidator.isEmailValid("lisauskas.rytis@yhaha.com");
            Assert.AreEqual(true, isValid, "Valid email address");
        }

        [TestMethod]
        public void Email_has_invalid_TLD()
        {
            var isValid = EmailValidator.isEmailValid("lisauskas.rytis@gmail.rusijas");
            Assert.AreEqual(false, isValid, "Not a valid email, invalid TLD");
        }

        //sis unit testas yra ne visai korektiskas, nes sie simboliai yra validus
        //source: https://en.wikipedia.org/wiki/Email_address
        //the allowed characters: printable characters !#$%&'*+-/=?^_`{|}~
        [TestMethod]
        public void Email_has_forbidden_characters_not_valid()
        {
            var isValid = EmailValidator.isEmailValid("lisauskas.&^!#4)(_+#!rytis@gmail.com");
            Assert.AreEqual(true, isValid, "Valid email");
        }

        [TestMethod]
        public void Email_has_at_sign_at_the_wrong_place_not_valid()
        {
            var isValid = EmailValidator.isEmailValid("lisaus@kas.rytis@gmail.com");
            Assert.AreEqual(false, isValid, "Not a valid email, @ in the middle of the name");
        }

        //sis unit testas nera visai logiskas
        //nes jis jau turi 2 @ simbolius, tai kaip ir nelabai validus is viso, o ne del to kad domaino neturi
        //reiktu atskirti i du atskirus.
        [TestMethod]
        public void Email_does_not_have_domain()
        {
            var isValid = EmailValidator.isEmailValid("lisauskas.rytis@.com");
            Assert.AreEqual(false, isValid, "Not a valid email, no domain");
        }
        
        [TestMethod]
        public void Email_has_two_at_signs()
        {
            var isValid = EmailValidator.isEmailValid("lisa@uskas.rytis@yahoo.com");
            Assert.AreEqual(false, isValid, "Email has two at signs");
        }

        [TestMethod]
        public void Email_does_not_have_TLD()
        {
            var isValid = EmailValidator.isEmailValid("lisaus@kas.rytis@gmail.");
            Assert.AreEqual(false, isValid, "Not a valid email, no TLD");
        }
    }
}
