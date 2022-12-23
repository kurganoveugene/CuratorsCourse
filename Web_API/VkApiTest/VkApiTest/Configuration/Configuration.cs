using System.Reflection;
using Aquality.Selenium.Core.Utilities;
using Aquality.Selenium.Core.Configurations;

namespace VkApiTest.Configuration
{
    public static class Configuration
    {
        public static string StartUrl 
        {
            get
            {
                var pathToConfigFile = $"Resources.Environment.config.json";
                var config =  new JsonSettingsFile(pathToConfigFile, Assembly.GetCallingAssembly());
                return config.GetValue<string>("startUrl");
            }
        }    
        public static string ApiRef
        {
            get
            {
                var pathToConfigFile = $"Resources.Environment.config.json";
                var config = new JsonSettingsFile(pathToConfigFile, Assembly.GetCallingAssembly());
                return config.GetValue<string>("api");
            }
        }

        public static string ApiVersion
        {
            get
            {
                var pathToConfigFile = $"Resources.Environment.config.json";
                var config = new JsonSettingsFile(pathToConfigFile, Assembly.GetCallingAssembly());
                return config.GetValue<string>("apiVersion");
            }
        }

        public static string GetTestData(string fieldName) 
        {
            var pathToTestDataFile = $"Resources.Environment.testData.json";
            var testData = new JsonSettingsFile(pathToTestDataFile, Assembly.GetCallingAssembly());
            return testData.GetValue<string>(fieldName);
            
        }

        public static string GetApiRoute(string routeName)
        {
            var pathToRouteFile = $"Resources.Environment.API.routes.json";
            var testData = new JsonSettingsFile(pathToRouteFile, Assembly.GetCallingAssembly());
            return testData.GetValue<string>(routeName);

        }
    }
}
