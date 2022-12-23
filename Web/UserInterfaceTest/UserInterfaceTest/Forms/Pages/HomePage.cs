using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;


namespace UserInterfaceTest.Forms.Pages
{
    public class HomePage : BaseAppForm
    {

        private IButton NextPage => ElementFactory.GetButton(By.XPath("//a[@class='start__link']"),"Next page link");
        public HomePage() : base(By.XPath("//button[@class='start__button']"),"'No' button") 
        {
        }

        public void ClickLink() => NextPage.Click();
    }
}
