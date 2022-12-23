using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;


namespace VkApiTest.Forms
{
    public class MyPage : BaseAppForm
    {

        private string commentTemplate => "//div[contains(@class,'post') and contains(@class,'own')][{0}]//div[contains(@class,'dived')][{1}]//div[@class='wall_reply_text']";
        private string commentAuthorTemplate => "//div[contains(@class,'post') and contains(@class,'own')][{0}]//div[contains(@class,'dived')][{1}]//a[@class='author']";

        private string NextCommentsTemplate => "//div[contains(@class,'post') and contains(@class,'own')][{0}]//a[contains(@class,'replies')]";
        private string PostReactionButtonTemplate => "//div[contains(@class,'post') and contains(@class,'own')][{0}]//div[@data-reaction-set-id='reactions']";
        private By LastPostXPath = By.XPath("//div[contains(@class,'post') and contains(@class,'own')][1]"); 
        public MyPage() : base(By.XPath("//*[@class='page_name']"),"User name label") { }

        public string LastPostText => ElementFactory.GetLabel(By.XPath("//div[contains(@class,'post') and contains(@class,'own')][1]//div[contains(@class,'wall') and contains(@class,'post_text')]"),
                                                              "Last post text").Text;
        public string LastPostPhotoLink => ElementFactory.GetLink(By.XPath("//div[contains(@class,'post') and contains(@class,'own')][1]//div[contains(@class,'sized')]//a"),
                                                                  " last post Photo link").Href;
        

        public string GetCommentText(int postNumber, int commentNumber) 
        {
            return ElementFactory.GetLabel(By.XPath(string.Format(commentTemplate,postNumber,commentNumber)),$"Comment {commentNumber} from post {postNumber} label").Text;
        }

        public int GetCommentAuthorId(int postNumber, int commentNumber)
        {
            var authorLabel = ElementFactory.GetLabel(By.XPath(string.Format(commentAuthorTemplate, postNumber, commentNumber)), $"Comment author {commentNumber} from post {postNumber} label");
            return int.Parse(authorLabel.GetAttribute("data-from-id"));
        }
        public void ClickOnNextComments(int postNumber) 
        {
            ElementFactory.GetButton(By.XPath(string.Format(NextCommentsTemplate, postNumber)),$"Next comment button for post{postNumber}").Click();
        }

        public void LikePost(int postNumber) 
        {
            ElementFactory.GetButton(By.XPath(string.Format(PostReactionButtonTemplate, postNumber)), $"Reaction button for post{postNumber}").Click();
        }
        public int GetLastPostAthorId()
        {
            var elementId = ElementFactory.GetLabel(LastPostXPath, "Last post").GetAttribute("id");
            elementId = elementId.Remove(elementId.IndexOf('_'));
            elementId = elementId.Remove(0,elementId.IndexOf('t')+1);
            return int.Parse(elementId);
        }

    }
}
