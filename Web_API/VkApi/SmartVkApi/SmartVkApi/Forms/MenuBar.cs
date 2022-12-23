using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace SmartVkApi.Forms
{
     public class MenuBar: Form
    {
        public MenuBar() : base(By.XPath("//div[@id = 'side_bar']//li[@id = 'l_pr']"), "menu bar") { }
        public void ClickMyProfileButton() => FormElement.WaitAndClick();
    }
}
