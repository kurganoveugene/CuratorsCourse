using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using Rest_API.Utils;

Console.WriteLine(StringUtils.Config.GetValue<Array>("dataForPost.params").ToString());
//Console.WriteLine(StringUtils.paramsstring(StringUtils.Config.GetValue<string>("dataForPost.params"))

namespace Rest_API.Utils
{

    internal class StringUtils
    {
        public static ISettingsFile Config => new JsonSettingsFile("config.json");
        private const string Latin = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static char RandLatinChar() => Latin[RandomUtils.RandNumberForLatin()];

        public static string RandomLatinstringCapital(int lenght)
        {
            string randstring = string.Empty;
            for (int i = 0; i < lenght; i++)
            {
                randstring += RandLatinChar();
            }
            return randstring;
        }



        //public static string CreateRouteStringForRequest(string method, string token, string version, string parameters)
        //{
        //    private IReadOnlyDictionary<string, string> Dict = Config.GetValueDictionary<string>("dataForPost.params");
        //string parametersString = string.Empty;
        //    foreach (var parameter in Dict){
        //    parametersString += parameter + '&';
        //}

        //    return method + '?' + parameters + "access_token=" + token + "&v=" + version;
        //}
        //public static string paramsstring(IReadOnlyList<string> list)
        //{
        //    string parametersString = string.Empty;
        //    for (int i = 0; i < list.Count; i++) parametersString += list[i] + '&';
        //    return parametersString;
        //}

        
    }
}