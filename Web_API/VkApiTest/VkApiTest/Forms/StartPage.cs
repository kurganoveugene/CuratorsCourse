using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VkApiTest.Forms
{
    public class StartPage : BaseAppForm
    {
        private ITextBox LoginInput = ElementFactory.GetTextBox(By.Id("index_email"), "login input");
        private IButton SignInButton = ElementFactory.GetButton(By.XPath("//button[contains(@class,'signInButton')]"), "Sign in button");
        public StartPage() : base(By.Id("index_email"),"login input") 
        {
        
        }

        public void InputLogin(string text) => LoginInput.SendKeys(text);
        public void ClickOnSignIn() => SignInButton.Click();
    }
}
