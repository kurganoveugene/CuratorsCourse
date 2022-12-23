using Aquality.Selenium.Browsers;
using NUnit.Framework;
using SmartVkApi.Configurations;

namespace SmartVkApi.Tests
{
    public class BaseTest
    {
        public Browser browser;
        protected static string Url => Configuration.Url;

        [SetUp]
        public void SetUpBrowser()
        {
            browser = AqualityServices.Browser;
            browser.Maximize();
        }

        [TearDown]
        public void TearBrowserDown()
        {
            browser.Quit();
        }
    }
}
