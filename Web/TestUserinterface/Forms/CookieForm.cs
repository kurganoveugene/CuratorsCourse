using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Elements;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TestUserinterface.Forms
{
    class CookieForm : Form
    {
        public ElementFactory elementFactory;
        public IButton acceptButton;
        public CookieForm() : base(By.XPath("//button[@class='button button--solid button--transparent']"), "cookie form")
        {
            this.elementFactory = (ElementFactory)AqualityServices.Get<IElementFactory>();
            this.acceptButton = elementFactory.GetButton(this.Locator, "accept coockie button");
        }
    }
}
