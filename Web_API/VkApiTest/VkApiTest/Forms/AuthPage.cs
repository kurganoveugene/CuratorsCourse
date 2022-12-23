using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VkApiTest.Forms
{
    public class AuthPage : Form
    {
        private ITextBox PasswordInput => ElementFactory.GetTextBox(By.XPath("//input[@name='password']"), "password input");
        private IButton ContinueButton => ElementFactory.GetButton(By.XPath("//div[contains(@class,'buttonWrap')]//button"),"Continue button");
        public AuthPage() : base(By.XPath("//input[@name='password']"),"password input") 
        {
        }

        public void InputPassword(string text) => PasswordInput.SendKeys(text);
        public void Continue() => ContinueButton.Click();
    }
}
