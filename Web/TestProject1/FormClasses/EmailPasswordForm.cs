using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestProject1
{
    public class EmailPasswordForm : Form
    {
        public EmailPasswordForm() : base(By.XPath("//div[@class='login-form__section']//*[@for='accept-terms-conditions']"), "Email-Password form")
        {
        }

        public ITextBox PasswordField => ElementFactory.GetTextBox(By.XPath("//div[@class='login-form__field-row']//*[@placeholder='Choose Password']"), "Password field");
        public ITextBox EmailHeadField => ElementFactory.GetTextBox(By.XPath("//div[@class='align__cell']//*[@placeholder='Your email']"), "Email field");
        public ITextBox EmailDomainField => ElementFactory.GetTextBox(By.XPath("//div[@class='align__cell']//*[@placeholder='Domain']"), "Domain field");
        public DropdownMenu DomainNameDropdown => new DropdownMenu(By.XPath("//div[@class='dropdown__header']//*[@class='dropdown__field']"), "Dropdown Menu");
        public IButton OrgDomainName => ElementFactory.GetButton(By.XPath("//div[@class='dropdown__list']//*[text()[contains(.,'.org')]]"), "Domain .org button");
        public ICheckBox TermsConditions => ElementFactory.GetCheckBox(By.XPath("//span[@class='checkbox']//*[@for='accept-terms-conditions']"), "Terms and conditions checkbox");
        public IButton NextButton => ElementFactory.GetButton(By.XPath("//div[@class='align__cell button-container__secondary']//*[@class='button--secondary']"), "Next button");

        public void FieldFilling()
        {
            string text = RandomTextGenerator.Generate(10);
            PasswordField.SendKeys(Keys.Control + "a");
            PasswordField.SendKeys(text+RandomTextGenerator.GenerateNum());
            EmailHeadField.SendKeys(Keys.Control + "a");
            EmailHeadField.SendKeys(text);
            EmailDomainField.SendKeys(Keys.Control + "a");
            EmailDomainField.SendKeys(text);
            DomainNameDropdown.ClickAndWait();
            OrgDomainName.ClickAndWait();
            TermsConditions.ClickAndWait();
            NextButton.ClickAndWait();
        }

    }
    


}
