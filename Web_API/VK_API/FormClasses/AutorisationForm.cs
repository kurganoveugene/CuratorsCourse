using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VK_API
{
    public class AutorisationForm : Form
    {
        public AutorisationForm() : base(By.XPath("//div[@id='index_login']"), "Autorisation")
        {
        }
        private IButton SignInButton => ElementFactory.GetButton(By.XPath("//button[@id='index_login_button']"), "Log in");
        private ITextBox PhoneNumberTextBox => ElementFactory.GetTextBox(By.XPath("//input[@id='index_email']"), "Email ot Phone number");
        private ITextBox PasswordTextBox => ElementFactory.GetTextBox(By.XPath("//input[@id='index_pass']"), "Password");

        public void UserAutorisation(string password, string username)
        {
            PhoneNumberTextBox.ClearAndType(username);
            PasswordTextBox.ClearAndType(password);
            SignInButton.ClickAndWait();
        }

    }
}