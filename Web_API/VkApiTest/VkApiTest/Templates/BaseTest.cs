using NUnit.Framework;
using Aquality.Selenium.Browsers;
using VkApiTest.Configuration;

namespace VkApiTest.Templates
{
    public abstract class BaseTest
    {
        protected Browser browser;

        [SetUp]
        public void SetUp() 
        {
            browser = AqualityServices.Browser;
            browser.Maximize();
        }

        [TearDown]
        public void TearDown() 
        {
            browser.Quit();
        }

    }
}
