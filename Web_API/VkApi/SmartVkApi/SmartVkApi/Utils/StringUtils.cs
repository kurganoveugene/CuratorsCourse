using System;

namespace SmartVkApi.Utils
{
    public class StringUtils
    {
        private Random random = new();

        public string GetRandomString(int length)
        {
            var result = String.Empty;
            for (int i = 0; i < length; i++)
            {
                if (i % 2 == 0){ 
                    result += random.Next(0, 2) == 0 ? UpperChar : LowerChar;
                }
                else { 
                    result += random.Next(0, 2) == 0 ? Num : Space;
                }
            }
            return result;
        }

        private char UpperChar => Convert.ToChar(random.Next(65, 91));

        private char LowerChar => Convert.ToChar(random.Next(97, 123));

        private char Num => Convert.ToChar(random.Next(48, 58));

        private char Space => Convert.ToChar(32);
    }
}
