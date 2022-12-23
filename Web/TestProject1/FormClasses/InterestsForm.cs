using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using AutoIt;
using OpenQA.Selenium;
using System.IO;

namespace TestProject1
{
    public class InterestsForm : Form
    {
        public InterestsForm() : base(By.XPath("//div[@class='avatar-and-interests']//*[@class='avatar-and-interests__form']"), "Interests Form")
        {
        }

        public ICheckBox UnselectAllCheckBox => ElementFactory.GetCheckBox(By.XPath("//span[@class='checkbox small']//*[@for='interest_unselectall']"), "Unselect All CheckBox");
        public ICheckBox PoniesCheckBox => ElementFactory.GetCheckBox(By.XPath("//span[@class='checkbox small']//*[@for='interest_ponies']"), "Ponies CheckBox");
        public ICheckBox PoloCheckBox => ElementFactory.GetCheckBox(By.XPath("//span[@class='checkbox small']//*[@for='interest_polo']"), "Polo CheckBox");
        public ICheckBox EnveloppesCheckBox => ElementFactory.GetCheckBox(By.XPath("//span[@class='checkbox small']//*[@for='interest_enveloppes']"), "Enveloppes CheckBox");
        public ICheckBox CablesCheckBox => ElementFactory.GetCheckBox(By.XPath("//span[@class='checkbox small']//*[@for='interest_cables']"), "Cables CheckBox");
        public ICheckBox ClosetsCheckBox => ElementFactory.GetCheckBox(By.XPath("//span[@class='checkbox small']//*[@for='interest_closets']"), "Closets CheckBox");
        public ICheckBox TiresCheckBox => ElementFactory.GetCheckBox(By.XPath("//span[@class='checkbox small']//*[@for='interest_tires']"), "Tires CheckBox");
        public ICheckBox DoughCheckBox => ElementFactory.GetCheckBox(By.XPath("//span[@class='checkbox small']//*[@for='interest_dough']"), "Dough CheckBox"); 
        public ICheckBox QuestionsCheckBox => ElementFactory.GetCheckBox(By.XPath("//span[@class='checkbox small']//*[@for='interest_questions']"), "Questions CheckBox");
        public ICheckBox SnailsCheckBox => ElementFactory.GetCheckBox(By.XPath("//span[@class='checkbox small']//*[@for='interest_snails']"), "Snails CheckBox");
        public ICheckBox WindowsCheckBox => ElementFactory.GetCheckBox(By.XPath("//span[@class='checkbox small']//*[@for='interest_windows']"), "Windows CheckBox");
        public IButton UploadButton => ElementFactory.GetButton(By.XPath("//a[@class='avatar-and-interests__upload-button']"), "Upload Button");
        public IButton NextButton => ElementFactory.GetButton(By.XPath("//div[@class='align__cell']//*[@class='button button--stroked button--white button--fluid']"), "Next Button");

        public void CheckingBoxesAndLoadingImage()
        {
            UnselectAllCheckBox.ClickAndWait();
            for (int i = 0; i < 3; i++)
            {
                switch (RandomTextGenerator.GenerateNumSpecified(1))
                {
                    case 1:
                        PoniesCheckBox.ClickAndWait();
                        break;
                    case 2:
                        PoloCheckBox.ClickAndWait();
                        break;
                    case 3:
                        EnveloppesCheckBox.ClickAndWait();
                        break;
                    case 4:
                        CablesCheckBox.ClickAndWait();
                        break;
                    case 5:
                        ClosetsCheckBox.ClickAndWait();
                        break;
                    case 6:
                        TiresCheckBox.ClickAndWait();
                        break;
                    case 7:
                        DoughCheckBox.ClickAndWait();
                        break;
                    case 8:
                        QuestionsCheckBox.ClickAndWait();
                        break;
                    case 9:
                        SnailsCheckBox.ClickAndWait();
                        break;
                    case 0:
                        WindowsCheckBox.ClickAndWait();
                        break;
                    default: 
                        break;
                }
            }
            
            string currentDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\PHP4.png";
            UploadButton.Click();
            AutoItX.Sleep(1000);
            AutoItX.Send(currentDirectory);
            AutoItX.Sleep(1000);
            AutoItX.MouseMove(811, 599);
            AutoItX.MouseClick();
        }

        public void GoToPersonalDetailsForm()
        {
            NextButton.State.WaitForClickable();
            NextButton.Click();
        }
    }
}
