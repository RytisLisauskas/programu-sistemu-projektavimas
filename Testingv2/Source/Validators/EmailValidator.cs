using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject
{
    public static class EmailValidator
    {
        public static bool isEmailValid(string email)
        {
            int atPos = -1;
            for (int i = 0; i < email.Length; ++i)
            {
                if (email[i] == '@')
                {
                    atPos = i;
                    break;
                }
            }

            if (atPos == -1)
                return false;

            int tldPos = -1;
            for (int i = email.Length - 1; i >= 0; --i)
            {
                if (email[i] == '.')
                {
                    tldPos = i;
                    break;
                }
            }
            if (tldPos == -1)
                return false;

            if (tldPos == email.Length - 1 || tldPos - atPos <= 1) return false;

            for (int i = tldPos + 1; i < email.Length; ++i)
            {
                if (!Char.IsLetter(email, i)) return false;
            }

            for (int i = atPos + 1; i < tldPos; ++i)
            {
                if (!Char.IsLetter(email, i) && email[i] != '.') return false;
            }

            return true;
        }
    }
}
