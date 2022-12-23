using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;
using UserInterfaceTest.Forms.Pages.Cards;

namespace UserInterfaceTest.Forms.Pages
{
    public class GamePage : BaseAppForm
    {
        public FirstCardForm FirstCard => new FirstCardForm();
        public SecondCardForm SecondCard => new SecondCardForm();
        public ThirdCardForm ThirdCard => new ThirdCardForm();
        public HelpForm Help => new HelpForm();
        public CookiesForm Cookies => new CookiesForm();

        private ILabel Timer = ElementFactory.GetLabel(By.XPath("//div[contains(@class,'timer')]"),"main timer");

        public GamePage(): base(By.XPath("//button[contains(@class,'pagination__button')]"),"first page button") 
        {
        }
        public string GetTime() => Timer.GetText();

    }
}
