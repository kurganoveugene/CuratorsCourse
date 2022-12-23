using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Elements;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TestUserinterface.Forms
{
    class HelpForm : Form
    {
        public ElementFactory elementFactory;
        public IButton sendToBottom;
        public HelpForm() : base(By.ClassName("button button--solid button--blue help-form__close-button"), "help form")
        {
            this.elementFactory = (ElementFactory)AqualityServices.Get<IElementFactory>();
            this.sendToBottom = elementFactory.GetButton(By.XPath("//button[@class='button button--solid button--blue help-form__send-to-bottom-button']"), "send to bottom");
            
        }
    }
}
