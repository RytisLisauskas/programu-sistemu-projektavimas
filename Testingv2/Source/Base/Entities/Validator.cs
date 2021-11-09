using System;
using LibraryProject;

namespace ValidatorsUnitTests.Source.Base.Entities
{
    public class Validator
    {
        public bool ValidateEmail(string email) {
            return EmailValidator.isEmailValid(email);
        }

        public bool ValidatePassword(string password) {
            return PasswordValidator.IsPasswordValid(password);
        }

        public string ValidateNumber(string number) {
            return PhoneNumberValidator.isPhoneNumberValid(number);
        }

        public bool ValidateUser(User user) {
            return EmailValidator.isEmailValid(user.Email) &&
                PasswordValidator.IsPasswordValid(user.Password) &&
                PhoneNumberValidator.isPhoneNumberValid(user.PhoneNumber) != "";
        }
    }
}
