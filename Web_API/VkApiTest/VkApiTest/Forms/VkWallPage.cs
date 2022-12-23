using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VkApiTest.Forms
{
    public class VkWallPage : BaseAppForm
    {
        private ILink MoveToMyPageButton => ElementFactory.GetLink(By.XPath("//*[@id= 'l_pr']//a"), "My page button");
        public VkWallPage() : base(By.Id("main_feed"),"Feed block") {}
        public void MoveToMyPage() => MoveToMyPageButton.ClickAndWait();
    }
}
