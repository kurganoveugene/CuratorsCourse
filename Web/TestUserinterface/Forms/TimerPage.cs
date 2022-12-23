using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Elements;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TestUserinterface.Forms
{ 
    class TimerPage : Form
    {
        public ElementFactory elementFactory;
        public ILabel timer;
        public TimerPage() : base(By.XPath("//div[@class='timer timer--white timer--center']"), "page with timer")
        {
            this.elementFactory = (ElementFactory)AqualityServices.Get<IElementFactory>();
            this.timer = elementFactory.GetLabel(this.Locator, "timer");
        }
    }
}
