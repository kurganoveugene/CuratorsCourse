using Aquality.Selenium.Browsers;
using NUnit.Framework;
using TestUserinterface.Data;
using TestUserinterface.Forms;


namespace TestUserinterface.Tests
{
    class Tests : BaseTest
    {
        [Test]
         public void TestCase1()
        {
            string url = new Url().url;
            browser.GoTo(url);
            var welcomePage = new WelcomePage();
            Assert.That(welcomePage.State.WaitForDisplayed(), Is.EqualTo(true));
            welcomePage.clickHereButton.Click();
            var firstInputCard  = new FirstInputCard();
            Assert.That(firstInputCard.State.WaitForDisplayed(), Is.EqualTo(true));
            var credentials = new Credentials();
            firstInputCard.FillFields(credentials.password, credentials.email, credentials.domain, credentials.domainZone);
            firstInputCard.acceptCheckBox.Click();
            firstInputCard.nextButton.Click();
            var secondInputCard = new SecondInputCard();
            Assert.That(secondInputCard.State.WaitForDisplayed(), Is.EqualTo(true));
            secondInputCard.SetInterests(new Interests().interests);
            secondInputCard.UploadImage();
            secondInputCard.nextButton.WaitAndClick();
            Assert.That(new ThirdInputCard().State.WaitForDisplayed(), Is.EqualTo(true));
        }

        [Test]
        public void TestCase2()
        {
            string url = new Url().url;
            browser.GoTo(url);
            var welcomePage = new WelcomePage();
            Assert.That(welcomePage.State.WaitForDisplayed(), Is.EqualTo(true));
            welcomePage.clickHereButton.Click();
            var helpForm = new HelpForm();
            helpForm.sendToBottom.WaitAndClick();
            AqualityServices.ConditionalWait.WaitForTrue(() => !helpForm.State.IsDisplayed);
            Assert.That(helpForm.State.IsDisplayed, Is.EqualTo(false));
        }

        [Test]
        public void TestCase3()
        {
            string url = new Url().url;
            browser.GoTo(url);
            var welcomePage = new WelcomePage();
            Assert.That(welcomePage.State.WaitForDisplayed(), Is.EqualTo(true));
            welcomePage.clickHereButton.Click();
            var cookieForm = new CookieForm();
            cookieForm.State.WaitForDisplayed();
            cookieForm.acceptButton.Click();
            Assert.That(AqualityServices.ConditionalWait.WaitFor(() => !cookieForm.State.IsDisplayed), Is.EqualTo(true));
        }

        [Test]
        public void TestCase4()
        {
            string url = new Url().url;
            browser.GoTo(url);
            var welcomePage = new WelcomePage();
            welcomePage.clickHereButton.Click();
            var time = new TimerPage().timer.GetText();
            Assert.That(time, Is.EqualTo("00:00:00"));
            
        }
    }
}
