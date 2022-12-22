using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;


namespace Userinterface.Utils
{
    internal class Utils
    {
        
        static ISettingsFile Config => new JsonSettingsFile("config.json");

        public static string email = RandomstringCapital(Convert.ToInt32(Config.GetValue<string>("number_of_random_letters_for_email")));
        public static string pass = Randpass();
        public static string domain = RandomstringCapital(Convert.ToInt32(Config.GetValue<string>("number_of_random_letters_for_domain")));
        public static string Randpass()
        {
            string pass = string.Empty;
            Random rand = new Random();
            String cyrilic = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            int RandCyrilicNumber = rand.Next(cyrilic.Length);
            char RandCyrilicChar = cyrilic[RandCyrilicNumber];
            pass += RandCyrilicChar;
            pass += email;
            for(int i=0; i< Convert.ToInt32(Config.GetValue<string>("number_of_random_numbers_for_pass")); i++)
            {
                int number = rand.Next(0,10);
                pass += number.ToString();

            }
            return pass;
        }
        public static string RandomstringCapital(int lenght)
        {
            string randstring = string.Empty;
            Random rand = new Random();
            for (int i=0; i < lenght; i++) 
            {
                int randcapitalletter = rand.Next(0, 26);
                char letter = Convert.ToChar(randcapitalletter + 65);
                randstring += letter;
            }

            return randstring;
        }
    }
}