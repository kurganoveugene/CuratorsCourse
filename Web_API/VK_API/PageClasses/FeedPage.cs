using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VK_API
{
    public class FeedPage : Form
    {
        public FeedPage() : base(By.XPath("//div[@id='feed_rmenu']"), "Feed")
        {
        }
        public NavigationForm NavigationForm { get; private set; } = new();
    }
}
