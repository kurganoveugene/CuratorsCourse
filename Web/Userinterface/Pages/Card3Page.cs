namespace Userinterface.Pages
{
    internal class Card3Page: Form
    {
        public Card3Page() : base(By.ClassName("personal-details__form"), "Card3 Page") { }

        public bool IsPageOpened() => FormElement.State.WaitForDisplayed();
    }
}
