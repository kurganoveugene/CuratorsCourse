using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;
using UserInterfaceTest.Models;


namespace UserInterfaceTest.Forms.Pages.Cards
{
    public class FirstCardForm : BaseAppForm
    {
        private ITextBox PasswordInput => ElementFactory.GetTextBox(By.XPath("//input[contains(@placeholder,'Choose Password')]"), "Password input");
        private ITextBox EmailLoginInput => ElementFactory.GetTextBox(By.XPath("//input[contains(@placeholder,'Your email')]"), "Email login input");
        private ITextBox EmailServerInput => ElementFactory.GetTextBox(By.XPath("//input[contains(@placeholder,'Domain')]"), "Email server input");
        private ILabel EmailDomain => ElementFactory.GetLabel(By.XPath("//div[@class='dropdown__field']"),"domain input");
        private ICheckBox AcceptTermsAndConditions => ElementFactory.GetCheckBox(By.XPath("//label[@class='checkbox__label']"),
                                                                                       "Accept terms andc onditions checkbox");
        private IButton NextCard => ElementFactory.GetButton(By.XPath("//a[contains(@class,'button--secondary')]"),"move to 2 card button");
        private string ItemXPathTemplate = "//div[contains(@class,'list-item') and text() = '{0}']";
        
      

        public FirstCardForm() : base(By.XPath("//input[contains(@placeholder,'Choose Password')]"), "Password input")
        {
        }

        public void SetUser(User user)
        {
            PasswordInput.ClearAndType(user.Password);
            EmailLoginInput.ClearAndType(user.EmailLogin);
            EmailServerInput.ClearAndType(user.Server);
            EmailDomain.Click();
            var item = ElementFactory.GetLabel(By.XPath(string.Format(ItemXPathTemplate,user.Domain)),"domain item");
            item.Click();
        }

        public void ClickOnTermsCheckBox() => AcceptTermsAndConditions.Click();
        public void ClickNext()=> NextCard.Click();

    }
}
