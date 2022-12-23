using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterfaceTest.Models;

namespace UserInterfaceTest.Utils
{
    public class UserDataGenerator
    {
        private static char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private static char[] digits = "0123456789".ToCharArray();
        private static string[] domains = {".com",".jpg",".be"};
        private static Random random = new Random();
        private static int minLoginLength = int.Parse(Configuration.Configuration.GetTestData("minLoginLength"));
        private static int maxLoginLength = int.Parse(Configuration.Configuration.GetTestData("maxLoginLength"));
        private static int minPasswordLength = int.Parse(Configuration.Configuration.GetTestData("minPasswordLength"));
        private static int maxPasswordLength = int.Parse(Configuration.Configuration.GetTestData("maxPasswordLength"));


        public static User GetUser() 
        {
            User user = new User();
            user.EmailLogin = GenerateString(letters[random.Next(letters.Length)],
                                                               random.Next(minLoginLength,maxLoginLength));
            user.Password = GenerateString(user.EmailLogin.ElementAt(0),
                                                             random.Next(minPasswordLength,maxPasswordLength));
            user.Server = GenerateString(letters[random.Next(letters.Length)],
                                                             random.Next(minLoginLength, maxLoginLength));
            user.Domain = domains[random.Next(domains.Length)];
            return user;
        }

        private static string GenerateString(char firstLetter, int length) 
        {
            StringBuilder builder = new StringBuilder(firstLetter);

            for (int i = 0; i < length-1; i++)
            {
                if (random.Next(0, 1) % 2 == 0)
                {
                    builder.Append(letters[random.Next(letters.Length)]);
                }
                else
                {
                    builder.Append(digits[random.Next(digits.Length)]);
                }
            }
            builder.Insert(random.Next(1,length-1), digits[random.Next(digits.Length)]);
            return builder.ToString();

        }
    }
}
