using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;

namespace UserInterfaceTest.Forms.Pages.Cards
{
    public class ThirdCardForm : BaseAppForm
    {
        public ThirdCardForm() : base(By.XPath("//div[@class='personal-details']"), "Personal details block")
        {
        }

    }
}
