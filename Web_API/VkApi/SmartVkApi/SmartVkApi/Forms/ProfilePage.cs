using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace SmartVkApi.Forms
{
    public class ProfilePage : Form
    {
        
        public ProfilePage() : base(By.ClassName("page_avatar_img"), "profile page") { }

        public void WaitForOpen() => State.WaitForDisplayed();
    }
}
