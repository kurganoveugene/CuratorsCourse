using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK_API.Pages
{
    internal class LoginPage : Form
    {
        public LoginPage() : base(By.ClassName("vkc__EnterLogin__content"), "Login Page") { }

        private ITextBox LoginTextbox = ElementFactory.GetTextBox(By.ClassName("vkc__TextField__input"), "Login Textbox");

        private IButton ContinueButtonPhone = ElementFactory.GetButton(By.XPath("//div[@class='vkc__EnterLogin__button']//button"), "Continue button phone");

        private IButton ContinueButtonPassword = ElementFactory.GetButton(By.XPath("//div[@class='vkc__EnterPasswordNoUserInfo__buttonWrap']//button"), "Continue button password");

        public void ClickLoginTextbox() => LoginTextbox.Click();

        public void ClickContinueButtonPhone() => ContinueButtonPhone.Click();
        public void ClickContinueButtonPass() => ContinueButtonPassword.Click();

        public void TypeTextIntoLoginTextbox(string text) => LoginTextbox.Type(text);
        public void WaitForPasswordFieldExist() => ContinueButtonPassword.State.WaitForDisplayed();
    }
}