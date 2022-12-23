using NUnit.Framework;
using Aquality.Selenium.Browsers;
using UserInterfaceTest.Configuration;

namespace UserInterfaceTest.Templates
{
    public abstract class BaseTest
    {
        protected Browser browser = AqualityServices.Browser;

        [SetUp]
        public void SetUp() 
        {
            
            browser.Maximize();
            browser.GoTo(Configuration.Configuration.StartUrl);
            browser.WaitForPageToLoad();
        }

        [TearDown]
        public void TearDown() 
        {
            browser.Quit();
        }

    }
}
