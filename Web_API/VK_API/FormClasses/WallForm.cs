using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VK_API
{
    public class WallForm : Form
    {
        public WallForm() : base(By.XPath("//div[@id='profile_wall']"), "Wall")
        {

        }

        public bool IsPostExist(string userId, string id)
        {           
            return ElementFactory.GetLabel(By.XPath($"//div[contains(@id,'{userId}_{id}') and contains(@class,'wall_post_cont')]"), "wall post").State.WaitForDisplayed();
        }

        public string GetNewPostMessage(string userId, string id)
        {
            return ElementFactory.GetLabel(By.XPath($"//div[contains(@id,'{userId}_{id}') and contains(@class,'wall_post_cont')]"), "Changed wall post").Text;
        }

        public bool IsPictureExists(string postUserId, string postId, string pictureOwner, string pictureId)
        {
            return ElementFactory.GetLabel(By.XPath($"//div[contains(@id,'{postUserId}_{postId}')]//*[@data-photo-id='{pictureOwner}_{pictureId}']"), "picture").State.WaitForDisplayed();
        }

        public bool IsCommentExists(string postUserId, string commentId)
        {
            return ElementFactory.GetLabel(By.XPath($"//div[contains(@id,'{postUserId}_{commentId}')]"), "Comment").State.WaitForDisplayed();
        }

        public void ClickShowComments(string postUserId, string postID)
        {          
           ElementFactory.GetLabel(By.XPath($"//a[contains(@onclick,'{postUserId}_{postID}')]//*[@class='js-replies_next_label']"), "Open next reply").Click();
        }

        public void ClickLike(string postUserId, string postID)
        {
            ElementFactory.GetButton(By.XPath($"//div[contains(@data-reaction-target-object,'{postUserId}_{postID}')]"), "Like button").Click();
        }

        public bool IsPostDeleted(string userId, string id)
        {
            return ElementFactory.GetLabel(By.XPath($"//div[contains(@id,'{userId}_{id}') and contains(@class,'wall_post_cont')]"), "wall post").State.WaitForNotDisplayed();
        }

    }
}
