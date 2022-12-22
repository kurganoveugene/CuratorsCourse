namespace Userinterface.Pages
{
    internal class Card1Page : Form
    {
        public Card1Page() : base(By.ClassName("login-form"), "Card1 Page") { }

        private ITextBox PasswordTextbox => ElementFactory.GetTextBox(By.XPath("//div[@class=\"login-form__field-row\"]//input"), "Password textbox");

        private ITextBox EmailTextbox => ElementFactory.GetTextBox(By.XPath("//div[@class=\"align__cell\"]//input[@placeholder=\"Your email\"]"), "Email textbox");

        private ITextBox DomainTextbox => ElementFactory.GetTextBox(By.XPath("//div[@class=\"align__cell\"]//input[@placeholder=\"Domain\"]"), "Domain textbox");

        private IComboBox DomainNameCombobox => ElementFactory.GetComboBox(By.ClassName("dropdown__field"), "Domain name combobox");

        private IList<IComboBox> Domains => ElementFactory.FindElements<IComboBox>(By.XPath("//*[@class=\"dropdown__list\"]//div"), "Domain combobox");

        private ICheckBox TermsCheckbox => ElementFactory.GetCheckBox(By.ClassName("checkbox__label"), "Terms checkbox");

        private ILink Card2PageLink => ElementFactory.GetLink(By.ClassName("button--secondary"), "Card2 Page link");

        private IButton HideHelpButton => ElementFactory.GetButton(By.XPath("//div[@class=\"align__cell u-right\"]//button"), "Hide help button");

        private ILabel HelpForm => ElementFactory.GetLabel(By.ClassName("help-form__title"), "Help form");

        private IButton CookiesButton => ElementFactory.GetButton(By.XPath("//div[@class=\"align__cell\"]//button[contains(text(),\"Not really, no\")]"), "Assept cookies button");

        private ILabel CookiesForm => ElementFactory.GetLabel(By.ClassName("cookies"), "Cookies form");

        private ILabel Timer => ElementFactory.GetLabel(By.XPath("//div[contains(@class, \"timer\")]"), "Timer");

        public bool IsPageOpened() => FormElement.State.WaitForDisplayed();

        public void ClickToPassword() => PasswordTextbox.Click();

        public void ClearPasswordTextboxAndType(string text) { PasswordTextbox.ClearAndType(text); }

        public void ClickToEmail() => EmailTextbox.Click();

        public void ClearEmailTextboxAndType(string text) { EmailTextbox.ClearAndType(text); }

        public void ClickToDomain() => DomainTextbox.Click();

        public void ClearDomainTextboxAndType(string text) => DomainTextbox.ClearAndType(text);

        public void ClickToDomainNameCombobox() => DomainNameCombobox.Click();

        private IComboBox ChoseRandomDomain()
        {
            Random rand = new Random();
            int rand_element_number = rand.Next(1, Domains.Count);
            return Domains[rand_element_number];
        }
        public void ClickToRandomDomain() => ChoseRandomDomain().Click();

        public void AsseptTerms(){ if (!TermsCheckbox.IsChecked) TermsCheckbox.Check();}

        public void ClickToNextPage() => Card2PageLink.Click();

        public void ClickHideHelp() => HideHelpButton.Click();

        public bool IsHelpFormHidden() => HelpForm.State.WaitForNotDisplayed();

        public void ClickCookies()
        {
            CookiesButton.State.WaitForDisplayed();
            CookiesButton.Click();
        }

        public bool CookiesFormIsHidden() => CookiesForm.State.WaitForNotDisplayed();

        public string GetTimerText() => Timer.GetText();
         
    }
        
    
}
