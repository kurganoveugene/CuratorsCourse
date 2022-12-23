using Aquality.Selenium.Core.Utilities;
using Aquality.Selenium.Core.Configurations;
using System.Reflection;

namespace SmartVkApi.Configurations
{
    public static class SettingsFileUtil
    {
        public static ISettingsFile CurrentEnvironment(string fileName)
        {
            var pathToFile = $"Resources.{fileName}.json";
            return  new JsonSettingsFile(pathToFile, Assembly.GetCallingAssembly());
        }
    }
}
