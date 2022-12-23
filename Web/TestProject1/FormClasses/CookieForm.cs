using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TestProject1
{
    class CookieForm : Form
    {
        public CookieForm() : base(By.XPath("//div[@class='align__cell']//*[@class='button button--solid button--transparent']"), "Cookie Form")
        {
        }
        public IButton AcceptCookiesButton => ElementFactory.GetButton(By.XPath("//div[@class='align__cell']//*[@class='button button--solid button--transparent']"), "AcceptCookies Button");

        public void AcceptingOurCorporateOverlords()
        {
            AcceptCookiesButton.Click();
        }
    }
}
