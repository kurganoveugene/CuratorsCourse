using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VK_API.Pages
{
    public class ProfilePage : Form
    {
        public ProfilePage() : base(By.ClassName("profile_content"), "Profile page") { }

        public string postID {get;set;}

        private ILabel UserWhoPosted => ElementFactory.GetLabel(By.XPath("//div[@id='wpt736399486_" + postID + "']//preceding::a[@class='author']"), "User who posts");

        private ILabel PostsText => ElementFactory.GetLabel(By.XPath("//div[@id='wpt736399486_" + postID + "']/div"), "Text in post");

        private ILabel PostImage => ElementFactory.GetLabel(By.XPath("//div[@id='wpt736399486_" + postID + "']//a"), "Photo in post");

        private IButton LikeButton => ElementFactory.GetButton(By.XPath("//div[@class='like_wrap _like_wall736399486_" + postID + " ']//div[@class='PostBottomActionContainer PostButtonReactionsContainer']"), "Like button");
        private ILabel UserWhoCommented => ElementFactory.GetLabel(By.XPath("//div[@id='replies_wrap736399486_" + postID + "']//a[@class='author']"), "User who commented");

        private IButton ShowNextCommentButton => ElementFactory.GetButton(By.XPath("//div[@id='replies_wrap736399486_" + postID + "']//span[@class='js-replies_next_label']"), "Show next comment button");
        
        private IButton LikeButtonAcive => ElementFactory.GetButton(By.XPath("//div[@class='like_wrap _like_wall736399486_" + postID + " ']//div[@class='PostButtonReactions__icon PostButtonReactions__icon--custom PostButtonReactions__icon--animationActive']"), "Like button Active");
        
        
        public bool IsPostDisplayed() => PostsText.State.WaitForDisplayed();

        public string GetIdUserWhoPosted() => UserWhoPosted.GetAttribute("href");

        public string GetTextFromPost() => PostsText.Text;

        public string GetImageIdFromPost() => PostImage.GetAttribute("href");

        public bool WaitForImageDisplayed() => PostImage.State.WaitForDisplayed();

        public string GetUserIDWhoCommented() => UserWhoCommented.GetAttribute("href");

        public void ClicktoShowNextCommentButton() => ShowNextCommentButton.Click();

        public void AddLike() => LikeButton.Click();

        public bool IsPostDeleted() => PostsText.State.WaitForNotDisplayed();

        public void WaitForActiveLike() => LikeButtonAcive.State.WaitForDisplayed();
    }
 }
