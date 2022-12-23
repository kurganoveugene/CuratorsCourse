using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Elements;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TestUserinterface.Forms
{
    class FirstInputCard : Form
    {
        public ILabel pageIndicator;
        public ITextBox choosePasswordField;
        public ITextBox domainField;
        public ITextBox yourEmailField;
        public IButton cancelButton;
        public IButton dropDownButton;
        public IButton nextButton;
        public ICheckBox acceptCheckBox;
        public ElementFactory elementFactory;
        public ICheckBox acceptCheckBox2;
         
        public FirstInputCard() : base((By.XPath("//div[@class='page-indicator' and contains(text(), '1 /')]")), "first card to input information") 
            {
            this.elementFactory = (ElementFactory)AqualityServices.Get<IElementFactory>();
            this.pageIndicator =  elementFactory.GetLabel(this.Locator, "page indicator");
            this.choosePasswordField = elementFactory.GetTextBox(By.XPath("//input[@placeholder = 'Choose Password']"), "choose password field");
            this.yourEmailField = elementFactory.GetTextBox(By.XPath("//input[@placeholder = 'Your email']"), "your email field");
            this.domainField = elementFactory.GetTextBox(By.XPath("//input[@placeholder = 'Domain']"), "domain field");
            this.cancelButton = elementFactory.GetButton(By.ClassName("align__cell button-container__primary"), "cancel button");
            this.dropDownButton = elementFactory.GetButton(By.ClassName("dropdown__field"), "drop-down list of domain zone");
            this.nextButton = elementFactory.GetButton(By.ClassName("button--secondary"), "next button");
            this.acceptCheckBox = elementFactory.GetCheckBox(By.ClassName("checkbox__box"), "accept checkbox");
            this.acceptCheckBox2 = elementFactory.GetCheckBox(By.XPath("//input[@type='checkbox']"), "accept checkbox2");
            }

        public void FillFields(string password, string email, string domain, string domainZone)
        {
            choosePasswordField.ClearAndType(password);
            yourEmailField.ClearAndType(email);
            domainField.ClearAndType(domain);
            SetDomainZone(domainZone);
        }

        private void SetDomainZone(string domainZone)
        {
            this.dropDownButton.Click();
            var labels = this.elementFactory.FindElements<ILabel>(By.ClassName("dropdown__list-item"));
            foreach(ILabel label in labels)
                if(label.GetText() == domainZone) 
                { 
                    label.Click();
                    break;
                }
        }
    }
}
