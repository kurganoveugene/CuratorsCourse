using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TestProject1  
{
    public class WelcomePage : Form
    {
        public WelcomePage() : base(By.XPath("//div[@class='view__row']//*[@class='start__button']"), "Welcome page")
        {
            
        }

        public IButton NextPageButton => ElementFactory.GetButton(By.XPath("//div[@class='view__row']//*[@class='start__link']"), "Next page button");

        public void GoToRegistrationPage()
        {
            NextPageButton.ClickAndWait();
        }
    }
}
