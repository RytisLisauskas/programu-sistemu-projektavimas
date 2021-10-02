using System;
using System.Collections.Generic;
using ValidatorsUnitTests.Source.Utils;

namespace ValidatorsUnitTests
{
    public static class PasswordValidator
    {
        private const int RequiredLenght = 8;

        public static bool IsPasswordValid(string password)
        {
            Console.WriteLine("Password:{0} , lenght: {1}",password,password.Length);
            password = password.Trim(' ', '\t');
            if (IsRequiredLenght(password)) {
                if (!AreThereBadCharacters(password)) {
                    if (StringUtility.FindCharactersInLine(password,CharacterLines.CAPITAL_LETTERS)) {
                        if (StringUtility.FindCharactersInLine(password,CharacterLines.SPECIAL_SYMBOL_LINE)) {
                            return true;    
                        }
                    }
                }
            }

            return false;
        }

        private static bool IsRequiredLenght(string password) {
            return password.Length >= RequiredLenght;
        }

        private static bool AreThereBadCharacters(string password) {
            for (int currentLenght = 0; currentLenght < password.Length; currentLenght++) {
                if (!CheckIfBadSymbol(password[currentLenght])) {
                    return true;
                        }
            }
            return false;
        }

        private static bool CheckIfBadSymbol(char symbol) {
            return CharacterLines.SPECIAL_SYMBOL_LINE.Contains(symbol) || CharacterLines.ALL_LETTERS.Contains(symbol);
        }

    }
}