namespace UserInterfaceTest.Configuration
{
    public static class Configuration
    {
        public static string StartUrl => Environment.CurrentEnvironment.GetValue<string>("startUrl");
        public static string GetTestData(string fieldName) => Environment.CurrentTestData.GetValue<string>(fieldName);
    }
}
