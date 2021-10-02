using System;
using System.Collections.Generic;
using ValidatorsUnitTests.Source.Utils;

namespace ValidatorsUnitTests.Source.Validators
{
    public static class PhoneNumberValidator
    {
        private static List<CountryCode> Prefixes = new List<CountryCode>() {
           { new CountryCode("8","+370", 12) },
           { new CountryCode("7","+65", 8) }
        };


        public static bool IsPhoneNumberValid(string phoneNumber) {
            
            if (phoneNumber != null) {
                if (StringUtility.FindCharactersInLine(phoneNumber, CharacterLines.SPECIAL_CHARS_NO_NUMBERS)
                    || StringUtility.FindCharactersInLine(phoneNumber, CharacterLines.ALL_LETTERS))
                {
                    return false;
                }
                else {
                    phoneNumber = ChangePrefixIfNeeded(phoneNumber);
                    if (phoneNumber != null) {
                        return true;
                    }
                }
            }
           
            return false;
        }

        private static string ChangePrefixIfNeeded(string phoneNumber)
        {
            if (phoneNumber != null && phoneNumber.Trim().Length > 0)
            {
                foreach (CountryCode cc in Prefixes)
                {
                    if (phoneNumber.StartsWith(cc.PrefixToChange))
                    {
                        string newPhoneNumber = cc.ChangeTo + phoneNumber.Substring(1, phoneNumber.Length - 1);
                        if (newPhoneNumber.Length == cc.Length)
                        {
                            return newPhoneNumber;
                        }
                        return null;
                    }
                    if (phoneNumber.StartsWith(cc.ChangeTo)) {
                        if (phoneNumber.Length == cc.Length)
                        {
                            return phoneNumber;
                        }
                    }

                }
                return null;
            }
            return null;
        }

        private static bool IsLengthGood(string phoneNumber, int length) {
            return phoneNumber.Trim().Length == length ? true : false;
        }



        private class CountryCode {

            public string PrefixToChange { get; set; }
            public string ChangeTo { get; set; }
            public int Length { get; set; }

            public CountryCode( string prefix, string changeTo, int length) {
                this.PrefixToChange = prefix;
                this.ChangeTo = changeTo;
                this.Length = length;
            }

        }
    }
}
