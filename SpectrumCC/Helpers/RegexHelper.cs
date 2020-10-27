using System;
using System.Text.RegularExpressions;

namespace SpectrumCC.Helpers
{
    public static class RegexHelper
    {

        //Checks if string has special characters
        public static bool HasSpecialCharactersInString(string password)
        {
            var regex = new Regex("[!@#$%^&]");
            if (regex.IsMatch(password))
                return true;
            else
                return false;

        }

        //Returns true if password contains atleast one character and one numberic digit
        public static bool IsMixtureOfLetterAndDigits(string password)
        {
            var regexPattern = "^(?=.*[a-zA-Z])(?=.*[0-9])";
            var regex = new Regex(regexPattern);
            if (regex.IsMatch(password))
                return true;
            else
                return false;
        }

        //Checks if string has special characters
        public static bool HasSpecialCharacters(string password)
        {
            var regex = new Regex("^[A-Za-z0-9]$");
            if (regex.IsMatch(password))
                return true;
            else
                return false;

        }

        //Check if string is between min and max length
        public static bool IsBetweenCharacterLength(string password, int minNumber, int maxNumber)
        {
            var passwordLength = password.Length;
            if (passwordLength > minNumber && passwordLength < maxNumber)
                return true;
            else
                return false;
        }

        //Check if string contain any sequence of characters immediately
        public static  bool HasContainsAnySequence(string password)
        {
            Regex FindDup = new Regex(@"(..+)\1", RegexOptions.IgnoreCase);
            MatchCollection allMatches = FindDup.Matches(password);
            if (allMatches.Count > 0)
                return true;
            else
                return false;
        }
    }
}
