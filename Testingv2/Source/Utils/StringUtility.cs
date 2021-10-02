using System;
namespace ValidatorsUnitTests.Source.Utils
{
    public static class StringUtility
    {
        public static bool FindCharactersInLine(string password, string line)
        {
 
            for (int currentLenght = 0; currentLenght < password.Length; currentLenght++)
            {
                if (line.Contains(password[currentLenght]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
