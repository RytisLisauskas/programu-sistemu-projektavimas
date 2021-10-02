using System;
namespace ValidatorsUnitTests.Source.Validators
{
    public static class EmailValidator
    {
        private static string[] ValidDomains = { "gmail", "yahoo", "inbox" };
        private static string[] ValidTLD = { "com", "lt", "lv", "es" };

        public static bool isEmailValid(string email) {
            if (email.Trim().Length < 3)
            {
                return false;
            }
                if (email.Contains('@'))
                {
                    string[] parts = email.Split('@');
                    if (parts.Length != 2)
                    {
                        return false;
                    }
                    string address = parts[0];
                    string domainAndTLD = parts[1];
                    if (CheckForBadCharactersAtTheEndOfAddress(address) && domainAndTLD.Contains('.'))
                    {
                        string domain = domainAndTLD.Split('.')[0];
                        string TLD = domainAndTLD.Split('.')[1];
                        if (domainAndTLD.Split('.').Length == 2) {
                            if (IsDomainOrTLDValid(domain, ValidDomains)) {
                                if (IsDomainOrTLDValid(TLD,ValidTLD)) {
                                    return true;
                                }
                            }

                        }
                    }
                }
            
            return false;
        }

        private static bool CheckForBadCharactersAtTheEndOfAddress(string address) {
            if (address.EndsWith('.') || address.EndsWith('+')) {
                return false;
            }
            return true;
        }

        private static bool IsDomainOrTLDValid(string domainOrTLD, string[] domainsOrTLDs) {
            foreach (string entry in domainsOrTLDs) {
                if (domainOrTLD.Equals(entry)) {
                    return true;
                }
            }
            return false;
        }
    }
}
