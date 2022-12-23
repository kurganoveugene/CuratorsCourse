using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Utilities;
using Aquality.Selenium.Core.Configurations;
using System.Reflection;


namespace UserInterfaceTest.Configuration
{
    internal static class Environment
    {
        public static ISettingsFile CurrentEnvironment
        {
            get
            {
                var pathToConfigFile = $"Resources.Environment.{CurrentEnvironmentName}.config.json";
                return new JsonSettingsFile(pathToConfigFile, Assembly.GetCallingAssembly());
            }
        }
        public static ISettingsFile CurrentTestData
        {
            get
            {
                var pathToConfigFile = $"Resources.Environment.{CurrentEnvironmentName}.testData.json";
                return new JsonSettingsFile(pathToConfigFile, Assembly.GetCallingAssembly());
            }

        }

        public static string CurrentEnvironmentName
        {
            get 
            {
                var envName = AqualityServices.Get<ISettingsFile>().GetValue<string>("environment");
                return envName;
            }
        
        }
    }
}
