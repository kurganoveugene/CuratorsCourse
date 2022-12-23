using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;


namespace VK_API
{
    public class NavigationForm : Form
    {
        public NavigationForm() : base(By.XPath("//div[@id='side_bar']"), "Navigation")
        {
            
        }
        private IButton MyProfileButton => ElementFactory.GetButton(By.XPath("//span[contains(text(),'Моя страница') or contains(text(),'My profile')]"), "My Profile");

        public void GoToProfile()
        {
            MyProfileButton.ClickAndWait();
        }
    }
}
