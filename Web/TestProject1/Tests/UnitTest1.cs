using Aquality.Selenium.Browsers;
using NUnit.Framework;


namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var browser = AqualityServices.Browser;
            browser.Maximize();
            browser.GoTo("https://userinyerface.com/game.html%20target=");
            browser.WaitForPageToLoad();
            WelcomePage welcomePage = new();
            Assert.IsTrue(welcomePage.State.IsDisplayed, "Welcome page is not opened");
            welcomePage.GoToRegistrationPage();
            RegistrationPage registrationPage = new();
            Assert.IsTrue(registrationPage.IsEmailPasswordFormOpen(), "Registration page is not opened");
            registrationPage.EmailPasswordForm.FieldFilling();
            Assert.IsTrue(registrationPage.IsInterestsFormOpen(), "Interests form is not opened");
            registrationPage.InterestsForm.CheckingBoxesAndLoadingImage();
            browser.ScrollWindowBy(0,300);
            registrationPage.InterestsForm.GoToPersonalDetailsForm();
            Assert.IsTrue(registrationPage.IsPersonalDetailsFormOpen(), "Personal details form is not opened");
            browser.Quit();
        }

        [Test]
        public void Test2()
        {
            var browser = AqualityServices.Browser;
            browser.Maximize();
            browser.GoTo("https://userinyerface.com/game.html%20target=");
            browser.WaitForPageToLoad();
            WelcomePage welcomePage = new();
            Assert.IsTrue(welcomePage.State.IsDisplayed, "Welcome page is not opened");
            welcomePage.GoToRegistrationPage();
            RegistrationPage registrationPage = new();
            Assert.IsTrue(registrationPage.IsEmailPasswordFormOpen(), "Registration page is not opened");
            Assert.IsTrue(registrationPage.IsHelpFormDown(), "Help form is still up");
            browser.Quit();
        }

        [Test]
        public void Test3()
        {
            var browser = AqualityServices.Browser;
            browser.Maximize();
            browser.GoTo("https://userinyerface.com/game.html%20target=");
            browser.WaitForPageToLoad();
            WelcomePage welcomePage = new();
            Assert.IsTrue(welcomePage.State.IsDisplayed, "Welcome page is not opened");
            welcomePage.GoToRegistrationPage();
            RegistrationPage registrationPage = new();
            Assert.IsTrue(registrationPage.IsEmailPasswordFormOpen(), "Registration page is not opened");
            Assert.IsTrue(registrationPage.IsCookieFormOpen(), "Cookie form is not displayed ");
            Assert.IsTrue(registrationPage.IsCookieFormDissapeared(), "Cookie form is still up, button is not pressed");
            browser.Quit();
        }

        [Test]
        public void Test4()
        {
            var browser = AqualityServices.Browser;
            browser.Maximize();
            browser.GoTo("https://userinyerface.com/game.html%20target=");
            browser.WaitForPageToLoad();
            WelcomePage welcomePage = new();
            Assert.IsTrue(welcomePage.State.IsDisplayed, "Welcome page is not opened");
            welcomePage.GoToRegistrationPage();
            RegistrationPage registrationPage = new();
            Assert.IsTrue(registrationPage.IsEmailPasswordFormOpen(), "Registration page is not opened");
            Assert.IsTrue(registrationPage.IsTimerStartsAtZero(), "Timer didn't started at 00:00:00");
            browser.Quit();
        }
    }
}