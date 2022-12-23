using Aquality.Selenium.Browsers;
using NUnit.Framework;

namespace TestUserinterface.Tests
{

    class BaseTest
    {
        public Browser browser;

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
