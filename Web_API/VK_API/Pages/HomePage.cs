using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK_API.Pages
{
    public class HomePage : Form
    {
        public HomePage() : base(By.ClassName("IndexPageContent"), "Home Page") { }

        private IButton LoginButton => ElementFactory.GetButton(By.XPath("//button[contains(@class, 'VkIdForm__signInButton')]"), "Login button");

        public void ClickLogin() => LoginButton.Click();
    }
}