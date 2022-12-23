using NUnit.Framework;
using SmartVkApi.Configurations;
using SmartVkApi.Forms;
using SmartVkApi.Utils;

namespace SmartVkApi.Tests
{
    public class Tests : BaseTest
    {
        private readonly PageWallPosts wallPosts = new(); 
        
        [Test]
        public void Test1()
        {
            browser.GoTo(Url);
            var welcomePage = new WelcomePage();
            welcomePage.WaitForOpen();
            welcomePage.InputLogin(Configuration.Login);
            welcomePage.InputPassword(Configuration.Password);
            welcomePage.ClickEnterButton();
            var menuBar = new MenuBar();
            menuBar.ClickMyProfileButton();
            new ProfilePage().WaitForOpen();

            var message = new StringUtils().GetRandomString(Configuration.StringLength);
            var numOfPostsBefore = wallPosts.GetNumOfPosts(message, Configuration.PublisherId);
            var responseModel = new PostUtils().PushPostAndGetResponse(message);
            var postId = responseModel.GetPostId();
            var numOfPostsAfter = wallPosts.GetNumOfPosts(message, Configuration.PublisherId);
            Assert.AreEqual(numOfPostsBefore + 1, numOfPostsAfter, "The post was supposed to appear");

            var editedMessage = new StringUtils().GetRandomString(Configuration.StringLength);
            new PostEditiongUtils().EditPost(postId.ToString(), editedMessage);
            var imageId = wallPosts.GetImageId(postId);
            var messageInPost = wallPosts.GetPostMessage(postId);
            Assert.AreEqual(editedMessage, messageInPost, "The message was supposed to change");
            Assert.AreEqual(Configuration.MediaId, imageId, "The image is not correct");

            var messageForComment = new StringUtils().GetRandomString(Configuration.StringLength);
            var numOfCommentsBefore = wallPosts.GetNumOfComments(postId, Configuration.OwnerId);
            new CommentUtils().PushComment(postId.ToString(), messageForComment);
            wallPosts.ShowComments(postId);
            var numOfCommentsAfter = wallPosts.GetNumOfComments(postId, Configuration.OwnerId);
            Assert.AreEqual(numOfCommentsBefore, numOfCommentsAfter - 1, "The comment was supposed to appear");

            wallPosts.Like(postId);
            var likersModel = new LikeUtils().GetLikersModel(postId.ToString());
            var likersList = likersModel.GetItems();
            Assert.True(likersList.Contains(Configuration.OwnerId), "The like was supposed to appear");

            new PostUtils().DeletePost(postId.ToString());
            Assert.IsFalse(wallPosts.IsTherePost(postId), "The post was supposed to disappear");
        }
    }
}
