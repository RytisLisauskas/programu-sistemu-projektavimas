using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject
{
    public static class PhoneNumberValidator
    {
        public static string isPhoneNumberValid(string number, int lengthWithoutPrefix = 9, string prefix = "370")
        {
            for (int i = 0; i < number.Length; ++i)
            {
                if (!Char.IsNumber(number, i) && !(number[i] == '+' && i == 0)) return "";
            }
            if (number[0] == '+')
            {
                if (prefix == number.Substring(1, prefix.Length) && lengthWithoutPrefix == number.Length - prefix.Length)
                {
                    return number;
                }
                else return "";
            }
            else
            {
                if (number[0] == '8' && number.Length == lengthWithoutPrefix)
                {
                    return "+" + prefix + number.Substring(1);
                }
                else if (number.Length == lengthWithoutPrefix) return number;
                else return "";
            }
        }
    }
}