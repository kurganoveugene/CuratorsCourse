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
    public class FeedPage : Form
    {
        public FeedPage() : base(By.Id("main_feed"), "Feed page") { }

        private IButton ProfileButton => ElementFactory.GetButton(By.Id("l_pr"), "Profile button");

        public void ClickProfileButton() => ProfileButton.Click();
    }
}
