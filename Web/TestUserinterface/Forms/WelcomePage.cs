using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TestUserinterface.Forms
{
    class WelcomePage : Form
    {
        public IElement clickHereButton;
        
        public WelcomePage() : base((By.ClassName("start__link")), "welcome page")
        { 
            var elementFactory = AqualityServices.Get<IElementFactory>();
            this.clickHereButton = elementFactory.GetButton(this.Locator, "click here button"); 
         }
    }
}
