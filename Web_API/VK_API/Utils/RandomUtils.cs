namespace Rest_API.Utils
{
    internal class RandomUtils
    {
        private const int CountOfLatinChars = 26;
        private static Random rand = new Random();

        public static int RandNumberForLatin() => rand.Next(CountOfLatinChars);
    }
}