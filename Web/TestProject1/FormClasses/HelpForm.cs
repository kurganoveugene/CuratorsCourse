using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TestProject1
{
    class HelpForm : Form
    {
        public HelpForm() : base(By.XPath("//div[@class='help-form__container']//*[@class='button button--solid button--blue help-form__close-button']"), "Help Form")
        {
        }
        public IButton SendDownButton => ElementFactory.GetButton(By.XPath("//div[@class='align__cell u-right']//*[@class='button button--solid button--blue help-form__send-to-bottom-button']"), "Send down Button");

        public void SendFormDown()
        {
            SendDownButton.Click();
        }
    }
}
