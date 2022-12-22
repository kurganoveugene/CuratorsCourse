using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace Userinterface.Tests
{
    public class Tests
    {
        static ISettingsFile Config => new JsonSettingsFile("config.json");
        static ISettingsFile Testdata => new JsonSettingsFile("TestData.json");

        [SetUp]
        public void Setup()

        {
            AqualityServices.Browser.GoTo("https://userinyerface.com/");
        }

        [Test]
        public void TestCards()
        {

            var homepage = new Pages.HomePage();
            Assert.True(homepage.IsPageOpened(), "Home page isn't opened");
            homepage.GoToCard1Page();
            var card1page = new Pages.Card1Page();
            Assert.True(card1page.IsPageOpened(), "Card1 page isn't opened");
            card1page.ClickToPassword();
            card1page.ClearPasswordTextboxAndType(Utils.Utils.pass);
            card1page.ClickToEmail();
            card1page.ClearEmailTextboxAndType(Utils.Utils.email);
            card1page.ClickToDomain();
            card1page.ClearDomainTextboxAndType(Utils.Utils.domain);
            card1page.ClickToDomainNameCombobox();
            card1page.ClickToRandomDomain();
            card1page.AsseptTerms();
            card1page.ClickToNextPage();
            var card2page = new Pages.Card2Page();
            Assert.True(card2page.IsPageOpened(), "Card2 page isn't opened");
            card2page.ClickToUncheckAll();
            card2page.ChoseInterests(Convert.ToInt32(Testdata.GetValue<string>("number_of_random_interests")));
            card2page.ClickToUpload();
            card2page.UploadImage(Directory.GetCurrentDirectory() + Config.GetValue<string>("upload_file_path"));
            card2page.ClickNextButton();
            var card3page = new Pages.Card3Page();
            Assert.True(card3page.IsPageOpened(), "Card3 page isn't opened");
            AqualityServices.Browser.Quit();
        }

        [Test]
        public void TestHelpForm()
        {
            var homepage = new Pages.HomePage();
            Assert.True(homepage.IsPageOpened(), "Home page isn't opened");
            homepage.GoToCard1Page();
            var card1page = new Pages.Card1Page();
            Assert.True(card1page.IsPageOpened(), "Card1 page isn't opened");
            card1page.ClickHideHelp();
            Assert.True(card1page.IsHelpFormHidden(), "Home page isn't opened");
            AqualityServices.Browser.Quit();
        }

        [Test]
        public void TestCookies()
        {
            var homepage = new Pages.HomePage();
            Assert.True(homepage.IsPageOpened(), "Home page isn't opened");
            homepage.GoToCard1Page();
            var card1page = new Pages.Card1Page();
            Assert.True(card1page.IsPageOpened(), "Card1 page isn't opened");
            card1page.ClickCookies();
            Assert.True(card1page.CookiesFormIsHidden(), "Cookies form is opened");
            AqualityServices.Browser.Quit();
        }
        [Test]
        public void TestTimer()
        {
            var homepage = new Pages.HomePage();
            Assert.True(homepage.IsPageOpened(), "Home page isn't opened");
            homepage.GoToCard1Page();
            var card1page = new Pages.Card1Page();
            Assert.True(card1page.IsPageOpened(), "Card1 page isn't opened");
            Assert.That(Testdata.GetValue<string>("timers_time"), Is.EqualTo(card1page.GetTimerText()), "Time not equal");
            AqualityServices.Browser.Quit();
        }

    }
}