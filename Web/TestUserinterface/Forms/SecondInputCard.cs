using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Elements;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Forms;
using TestUserinterface.Data;
using OpenQA.Selenium;
using System.Collections.Generic;
using AutoItX3Lib;
using System.Threading;

namespace TestUserinterface.Forms
{
    class SecondInputCard : Form
    {   
        public ILabel pageIndicator;
        public ICheckBox unselectAll;
        public IButton nextButton;
        public IButton uploadButton;
        public ElementFactory elementFactory;
        public SecondInputCard() : base((By.XPath("//div[@class='page-indicator' and contains(text(), '2 /')]")), "second card to input information") 
            {
            this.elementFactory = (ElementFactory)AqualityServices.Get<IElementFactory>();
            this.pageIndicator =  elementFactory.GetLabel(this.Locator, "page indicator");
            this.unselectAll = elementFactory.GetCheckBox(By.XPath("//input[@id='interest_unselectall']/.."), "unselect all");
            this.nextButton = elementFactory.GetButton(By.XPath("//button[@class='button button--stroked button--white button--fluid']"), "next button", state: Aquality.Selenium.Core.Elements.ElementState.ExistsInAnyState);
            this.uploadButton = elementFactory.GetButton(By.XPath("//a[@class='avatar-and-interests__upload-button']"), "upload button");
            }

        public void SetInterests(List<string> userInterests)
        {
            this.unselectAll.Click();
            var interests = this.elementFactory.FindElements<ICheckBox>(By.XPath("//label[@class='checkbox__label']"));
            foreach (ICheckBox interest in interests)
            {
                var interestName = interest.FindChildElement<ICheckBox>(By.XPath("//input"), state: Aquality.Selenium.Core.Elements.ElementState.ExistsInAnyState).GetAttribute("id");
                foreach (string userInterest in userInterests)
                    if ($"interest_{userInterest}" == interestName)
                        interest.Click();
            }
        }

        public void UploadImage()
        {
            this.uploadButton.Click();
            AutoItX3 autoIt = new AutoItX3();
            string windowName = new BrowseImageWindow().windowName;
            autoIt.WinWait(windowName);
            autoIt.WinActivate(windowName);
            var path = System.IO.Path.GetFullPath(@"..\..\..\");
            path += @"Data\image.jpg"; 
            autoIt.Send(path);
            autoIt.Send("{ENTER}");
            Thread.Sleep(50);
        }
    }		
}
