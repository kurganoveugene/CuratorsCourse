using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TestProject1
{
    class RegistrationPage : Form
    {
        public RegistrationPage() : base(By.XPath("//div[@class='login-form']//*[@class='login-form__container']"), "Registration page")
        {
        }

        public EmailPasswordForm EmailPasswordForm => new();
        public InterestsForm InterestsForm => new();
        public PersonalDetailsForm PersonalDetailsForm => new();
        public HelpForm HelpForm => new();
        public CookieForm CookieForm => new();

        public ILabel Timer => ElementFactory.GetLabel(By.XPath("//div[@class='timer timer--white timer--center']"), "timer");

        public bool IsEmailPasswordFormOpen()
        {
            return EmailPasswordForm.State.WaitForDisplayed();
        }

        public bool IsInterestsFormOpen()
        {
            return InterestsForm.State.WaitForDisplayed();
        }

        public bool IsPersonalDetailsFormOpen()
        {
            return PersonalDetailsForm.State.WaitForDisplayed();
        }

        public bool IsCookieFormOpen()
        {
            return CookieForm.State.WaitForDisplayed();
        }

        public bool IsHelpFormDown()
        {
            HelpForm.SendFormDown();
            return HelpForm.State.WaitForNotDisplayed();
        }

        public bool IsCookieFormDissapeared()
        {
            CookieForm.AcceptingOurCorporateOverlords();
            return CookieForm.State.WaitForNotDisplayed();
        }

        public bool IsTimerStartsAtZero()
        {
            string timr = Timer.GetText();
            return timr == "00:00:00";
        }

    }
}
