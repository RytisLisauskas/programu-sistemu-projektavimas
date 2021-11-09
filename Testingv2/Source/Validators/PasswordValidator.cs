using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryProject
{
    public static class PasswordValidator
    {
        public static bool IsPasswordValid(string password, string specialSymbols = "")
        {
            int minLength = 5;
            if (password.Length < minLength) return false;

            bool hasUpperCase = false, hasSpecialSymbols = specialSymbols.Length == 0;

            foreach (char symbol in password)
            {
                if (Char.IsUpper(symbol)) hasUpperCase = true;
                if (specialSymbols.Contains(symbol)) hasSpecialSymbols = true;
            }

            return hasUpperCase && hasSpecialSymbols;
        }
    }
}