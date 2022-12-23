using NUnit.Framework;
using VkApiTest.Forms;
using VkApiTest.Configuration;
using VkApiTest.Templates;
using VkApiTest.Utils;
using System.Threading.Tasks;
using System.Threading;
using Aquality.Selenium.Browsers;


namespace VkApiTest
{
    public class VkTest : BaseTest
    {

        [Test]
        public async Task TestCase1()
        {
            browser.GoTo(Configuration.Configuration.StartUrl);
            browser.WaitForPageToLoad();

            string login = Configuration.Configuration.GetTestData("VkLogin"),
                password = Configuration.Configuration.GetTestData("VkPassword");
            int userId = int.Parse(Configuration.Configuration.GetTestData("pageId"));

            StartPage startPage = new StartPage();
            Assert.IsTrue(startPage.State.IsDisplayed,"Login page isn't displayed");
            startPage.InputLogin(login);
            startPage.ClickOnSignIn();
            AuthPage authPage = new AuthPage();
            Assert.IsTrue(authPage.State.WaitForDisplayed(), "Auth page isn't displayed");
            authPage.InputPassword(password);
            authPage.Continue();

            VkWallPage vkWall = new VkWallPage();
            Assert.IsTrue(vkWall.State.WaitForDisplayed(),"Auth failed, vk wall not loaded");
            vkWall.MoveToMyPage();
            MyPage myPage = new MyPage();
            Assert.IsTrue(myPage.State.WaitForDisplayed(), "My page isn't loaded");

            string postText = StringGenerator.GenerateString();
            string oldText = myPage.LastPostText;
            string requestResult = await VkApiUtil.PostOnWall(postText);
            Assert.AreNotEqual(string.Empty, requestResult,"Cannot make post with api");
            int postId = int.Parse(JsonUtil.ReadField(requestResult, new string[] { "response", "post_id" }));
            
            AqualityServices.ConditionalWait.WaitFor(()=>(oldText!= myPage.LastPostText));
            var actualText = myPage.LastPostText;
            Assert.AreEqual(postText, actualText , "Post isn't present on page");
            Assert.AreEqual(userId, myPage.GetLastPostAthorId(),"Last post user id isnt equal to user");
            
            string picture = Configuration.Configuration.GetTestData("photo"), 
                   newPostText = StringGenerator.GenerateString();
            requestResult = await VkApiUtil.EditOnWall(postId,newPostText,picture);
            Assert.AreNotEqual(string.Empty, requestResult, "Cannot edit post with api");
            AqualityServices.ConditionalWait.WaitFor(() => (postText != myPage.LastPostText));
            Assert.AreEqual(newPostText, myPage.LastPostText, "Post text hasn't changed ");
            Assert.AreEqual(picture, StringUtil.CutReference(myPage.LastPostPhotoLink),"Post photo isnt equal to source photo");
            
            string commentText = StringGenerator.GenerateString();
            requestResult = await VkApiUtil.CommentPostOnWall(postId,commentText);
            Assert.AreNotEqual(string.Empty, requestResult, "Cannot comment post using api");
            
            int latestPostNumber = 1, latestCommentNumber = 1;
            myPage.ClickOnNextComments(latestPostNumber);
            string commentActualText = myPage.GetCommentText(latestPostNumber, latestCommentNumber);
            int commentAuthorId = myPage.GetCommentAuthorId(latestPostNumber, latestCommentNumber);
            Assert.AreEqual(commentText, commentActualText, "Comment text from request and text on page are not equal");
            Assert.AreEqual(userId,commentAuthorId,"Comment author not equal to user");
            
            myPage.LikePost(latestPostNumber);
            Assert.IsTrue( await VkApiUtil.IsPostLikedByUser(postId, userId),"Post isn't liked by user");
            
            requestResult = await VkApiUtil.DeletePostOnWall(postId);
            Assert.AreEqual(Configuration.Configuration.GetTestData("successDelete"),JsonUtil.ReadField(requestResult,"response"),
                            "Api error while trying to delete post");
            Assert.AreNotEqual(postText,myPage.LastPostText,$"Post {postId} wasnt deleted ");
        }
    }
}