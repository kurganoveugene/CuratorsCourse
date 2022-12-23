using MlkPwgen;

namespace TestProject1
{
    public static class RandomTextGenerator
    {
        public static string Generate(int num)
        {
            return PasswordGenerator.Generate(length: num, allowed: Sets.Alphanumerics);
        }

        public static int GenerateNum()
        {
            System.Random rand = new System.Random();
            return rand.Next(0, 100);
        }

        public static int GenerateNumSpecified(int num)
        {
            return int.Parse(PasswordGenerator.Generate(length: num, allowed: Sets.Digits));
        }
    }
}
