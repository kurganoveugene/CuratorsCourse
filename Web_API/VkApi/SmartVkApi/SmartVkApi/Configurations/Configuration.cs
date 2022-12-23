using Aquality.Selenium.Core.Configurations;

namespace SmartVkApi.Configurations
{
    public static class Configuration
    {
        private static ISettingsFile ConfigFile => SettingsFileUtil.CurrentEnvironment("config");

        private static ISettingsFile CredentialsFile => SettingsFileUtil.CurrentEnvironment("credentials");
       
        private static ISettingsFile TestDataFile => SettingsFileUtil.CurrentEnvironment("testData");
    
        public static string PublisherId => TestDataFile.GetValue<string>("publisherId");
        
        public static string OwnerId => TestDataFile.GetValue<string>("ownerId");
        
        public static string MediaId => TestDataFile.GetValue<string>("mediaId");
        
        public static int StringLength => TestDataFile.GetValue<int>("stringLength");
        
        public static string Url => ConfigFile.GetValue<string>("url");
        
        public static string ApiUrl => ConfigFile.GetValue<string>("apiUrl");
        
        public static string ApiVersion => ConfigFile.GetValue<string>("apiVersion");
        
        public static string Login => CredentialsFile.GetValue<string>("login");
        
        public static string Password => CredentialsFile.GetValue<string>("password");
        
        public static string Token => CredentialsFile.GetValue<string>("token");
    } 
}
