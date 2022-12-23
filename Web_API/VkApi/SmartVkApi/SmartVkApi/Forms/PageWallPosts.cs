using System.Collections.Generic;
using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using SmartVkApi.Configurations;

namespace SmartVkApi.Forms
{
    public class PageWallPosts : Form
    {
        public PageWallPosts() : base(By.Id("page_wall_posts"), "page wall posts") { }
        
        private IList<ILabel> ListOfPosts => FormElement.FindChildElements<ILabel>(By.ClassName("_post_content"));

        public int GetNumOfPosts(string message, string authorId) { 
            var count = 0;
            var listOfPosts = ListOfPosts;
            foreach(ILabel post in listOfPosts){
                if (post.FindChildElements<ILabel>(By.XPath($"//div[text() = '{message}']")).Count != 0 
                    && post.FindChildElements<ILabel>(By.XPath($"//*[@class = 'author' and @href='/id{authorId}']")).Count != 0)
                {
                    count++;
                }
            } 
            return count;
        }

        private ILabel GetPost(int postId) => ElementFactory.GetLabel(By.XPath($"//div[@id='post{Configuration.OwnerId}_{postId}']"), $"post {postId}");

        public string GetPostMessage(int postId)
        {
            var post = GetPost(postId);
            var message = post.FindChildElement<ILabel>(By.ClassName("wall_post_text")).GetText();
            return message;
        }

        public string GetImageId(int postId)
        {
            var post = GetPost(postId);
            var imageId = post.FindChildElement<ILabel>(By.XPath("//*[@data-photo-id]")).GetAttribute("data-photo-id");
            imageId = imageId.Split("_")[1];
            return imageId;
        }

        public void ShowComments(int postId)
        {
            var showCommentsButton = ElementFactory.GetButton(By.XPath($"//div[@id='replies{Configuration.OwnerId}_{postId}']//*[@onclick]"), "show button");
            showCommentsButton.Click();
            ConditionalWait.WaitForTrue(() => GetListOfComments(postId).Count != 0);
        }

        private IList<ILabel> GetListOfComments(int postId)
        { 
            var commentsList = GetPost(postId).FindChildElements<ILabel>(By.XPath("//div[@data-answering-id]"));
            return commentsList;
        }

        public int GetNumOfComments(int postId, string requiredAuthorId)
        {
            var commentsList = GetListOfComments(postId);
            var counter = 0;
            foreach(ILabel comment in commentsList)
            {
                if (comment.GetAttribute("data-answering-id").Equals(requiredAuthorId))
                {
                    counter ++;
                }
            }
            return counter;
        }

        public void Like(int postId)
        {
            var post = GetPost(postId);
            var likeButton = post.FindChildElement<IButton>(By.XPath("//div[contains(@class, 'PostButtonReactionsContainer')]"), "like");
            likeButton.Click();
        }

        public bool IsTherePost(int postId)
        {
            ConditionalWait.WaitFor(() 
                => ElementFactory.FindElements<ILabel>(By.XPath($"//div[@id='post{Configuration.OwnerId}_{postId}']")).Count.Equals(0));
            var posts = ElementFactory.FindElements<ILabel>(By.XPath($"//div[@id='post{Configuration.OwnerId}_{postId}']"));
            return !posts.Count.Equals(0);
        }
    }
}
