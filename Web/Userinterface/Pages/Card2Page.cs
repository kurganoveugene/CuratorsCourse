using AutoItX3Lib;

namespace Userinterface.Pages
{
    internal class Card2Page: Form
    {
        public Card2Page() : base(By.ClassName("avatar-and-interests__form"), "Card2 Page") { }
        private IList<ICheckBox> InterestsCheckboxes => ElementFactory.FindElements<ICheckBox>(By.XPath("//*[@class=\"avatar-and-interests__interests-list__item\"]//label"), "InterestsCheckboxes");

        private ICheckBox UnselectCheckbox => ElementFactory.GetCheckBox(By.XPath("//*[@for=\"interest_unselectall\"]"), "Unselect checkbox");

        private IButton UploadButton => ElementFactory.GetButton(By.ClassName("avatar-and-interests__upload-button"), "Upload button");

        private IButton NextButton => ElementFactory.GetButton(By.XPath("//button[contains(text(),\"Next\")]"), "Next button");



        public bool IsPageOpened() => FormElement.State.WaitForDisplayed();

        public void ClickToUncheckAll() => UnselectCheckbox.Click();

        public void ChoseInterests(int NumberOfInterests)
        {
            int count = NumberOfInterests;
            Random rand = new Random();
            while(count > 0)
            {   
                int rand_checkbox = rand.Next(0, InterestsCheckboxes.Count);
                if (InterestsCheckboxes[rand_checkbox].IsChecked ||
                    InterestsCheckboxes[rand_checkbox].GetAttribute("for") == "interest_unselectall"||
                    InterestsCheckboxes[rand_checkbox].GetAttribute("for") == "interest_selectall") continue;
                InterestsCheckboxes[rand_checkbox].Check();
                count--;
            }
        }

        public void ClickToUpload() => UploadButton.Click();
        public void UploadImage(string path)
        {            
            AutoItX3 autoit = new AutoItX3();
            if (Convert.ToBoolean(autoit.WinWait("Open"))) autoit.WinActivate("Open");
            autoit.Send(path);
            autoit.Send("{Enter}");
        }

        public void ClickNextButton() => NextButton.Click();

    }
}


        