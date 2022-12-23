using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VK_API
{
    public class ProfilePage : Form
    {
        public ProfilePage() : base(By.XPath("//div[@id='page_avatar']"), "Profile")
        {
        }
        public NavigationForm NavigationForm { get; private set; } = new();
        public WallForm WallForm { get; private set; } = new();
    }
}
