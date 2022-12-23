using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;


namespace UserInterfaceTest.Forms.Pages
{
    public class HelpForm : BaseAppForm
    {
        private IButton SendToBottom => ElementFactory.GetButton(By.XPath("//button[contains(@class,'send-to-bottom')]"),"Send to bottom button");
        public HelpForm() : base(By.XPath("//h2[contains(@class,'form__title')]"),"Help form header") 
        {
        }

        public void ClickSendToBottom() => SendToBottom.Click();
    }
}
