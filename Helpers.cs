using System;
using System.Linq;
using System.Net.Mail;

namespace JsonPlaceholderTests
{
    public static class Helpers
    {
        private static Random random = new Random();
        public static bool IsValidEmailAddress(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static int GenerateRandomPositiveNumber(int maxValue)
        {
            return random.Next(0, maxValue);
        }
    }
}
