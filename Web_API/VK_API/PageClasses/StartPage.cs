using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VK_API
{
    public class StartPage : Form
    {
        public StartPage() : base(By.XPath("//div[@class='JoinForm']"), "Start")
        {
        }
        public AutorisationForm AutorisationForm { get; private set; } = new();
    }
}
