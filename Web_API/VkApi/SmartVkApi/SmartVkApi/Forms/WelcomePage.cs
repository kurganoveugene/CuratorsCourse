using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace SmartVkApi.Forms
{
    public class WelcomePage : Form
    {
         private ITextBox PasswordTextField => ElementFactory.GetTextBox(By.Id("index_pass"), "password");

         private ITextBox LoginTextField => ElementFactory.GetTextBox(By.Id("index_email"), "login");
         private IButton EnterButton => ElementFactory.GetButton(By.Id("index_login_button"), "enter");
         public WelcomePage() : base(By.Id("index_email"), "welcome page"){}

         public void WaitForOpen() => State.WaitForDisplayed();
         public void InputPassword(string password) => PasswordTextField.ClearAndType(password);

         public void InputLogin(string login) => LoginTextField.ClearAndType(login);

         public void ClickEnterButton() => EnterButton.Click();
    }
}
