namespace Userinterface.Pages
{
    internal class HomePage : Form
    {
        public HomePage() : base(By.ClassName("start__button"), "Home Page") { }

        private ILink Card1PageLink => ElementFactory.GetLink(By.ClassName("start__link"), "Card1Page button");

        public bool IsPageOpened() => FormElement.State.WaitForDisplayed();
       
        public void GoToCard1Page() => Card1PageLink.Click();
        
    }
}
