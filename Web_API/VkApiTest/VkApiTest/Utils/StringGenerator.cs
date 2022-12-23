using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiTest.Utils
{
    public static class StringGenerator
    {
        private static char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static int minLength = 10;
        private static int maxLength = 30;
        private static Random random = new Random();
        public static string GenerateString()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < random.Next(minLength, maxLength); i++)
            {
                builder.Append(letters[random.Next(letters.Length)]);
            }
            return builder.ToString();

        }
    }
}