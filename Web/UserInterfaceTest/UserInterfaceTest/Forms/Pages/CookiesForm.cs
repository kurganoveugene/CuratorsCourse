using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;

namespace UserInterfaceTest.Forms.Pages
{
    public class CookiesForm : BaseAppForm
    {
        private IButton AcceptCookiesButton = ElementFactory.GetButton(By.XPath("//button[contains(@class,'transparent')]"),"Accept cookies button");
        
        public CookiesForm() : base(By.XPath("//p[@class='cookies__message']"), "Cookies message label")
        {
        }

        public void AcceptCookies() => AcceptCookiesButton.Click();
    }
}
