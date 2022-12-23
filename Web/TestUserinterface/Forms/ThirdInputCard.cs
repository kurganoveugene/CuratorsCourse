using Aquality.Selenium.Forms;
using OpenQA.Selenium;


namespace TestUserinterface.Forms
{
    class ThirdInputCard : Form
    {
        public ThirdInputCard() : base((By.XPath("//div[@class='page-indicator' and contains(text(), '3 /')]")), "second card to input information")
        {
        }
    }
}
