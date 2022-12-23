using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;
using System.Collections.Generic;
using AutoItLib;

namespace UserInterfaceTest.Forms.Pages.Cards
{
    public class SecondCardForm : BaseAppForm
    {
        private IButton InputAvatar => ElementFactory.GetButton(By.XPath("//a[contains(@class,'interests__upload-button')]"),"Set avatar");
        private ICheckBox UnselectAll => ElementFactory.GetCheckBox(By.XPath("//span[contains(text(),'Unselect all')]//parent::div//span[@class='checkbox__box']"),
                                                                    "Unselect all checkbox");
        private IList<ICheckBox> CheckBoxes => ElementFactory.FindElements<ICheckBox>(By.XPath("//span[@class='checkbox__box']"));
        private IList<ILabel> CheckBoxText => ElementFactory.FindElements<ILabel>(By.XPath("//div[contains(@class,'interests-list__item')]//span[2]"));
        private IButton NextPage => ElementFactory.GetButton(By.XPath("//button[contains(@class,'button--white') and text()='Next']"),"Next card button");
        public SecondCardForm() : base(By.XPath("//button[contains(@class,'upload-button')]"), "download avatar button")
        {
        }

        public void SetAvatar(string filePath)
        {
            InputAvatar.Click();
            AutoItUtil.UploadFile(filePath);
        }    
        public void UnselectAllCheckboxes() => UnselectAll.Click();

        public int GetCheckBoxCount => CheckBoxes.Count;
        public void CheckInterest(int number) 
        {
            var checkBox = CheckBoxes[number];
            checkBox.Check();
        }

        public string GetInterestText(int number) 
        {
            return CheckBoxText[number].GetText();
        }

        public void ClickNext() => NextPage.Click();
    }
}
