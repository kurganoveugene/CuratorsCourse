using System;
using RestSharp;
using System.Threading.Tasks;


namespace VkApiTest.Utils
{
    public static class VkApiUtil
    {
        private static RestClient client = new RestClient(Configuration.Configuration.ApiRef);
        private static string PostLiked => "1";   

        public static async Task<string> PostOnWall( string text) 
        {
            string token = Configuration.Configuration.GetTestData("token"),
                   pageId = Configuration.Configuration.GetTestData("pageId");
            var request = new RestRequest(
               Configuration.Configuration.GetApiRoute("post"),
               Method.Post);

            request.AddParameter("owner_id", pageId);
            request.AddParameter("message", text);
            request.AddParameter("access_token", token);
            request.AddParameter("v", Configuration.Configuration.ApiVersion);
            var response = client.Post(request);
            if (!response.IsSuccessful)
            {
                return string.Empty;
            }
            return response.Content;
        }
        public static async Task<string> EditOnWall(int post_id, string newText, string pictureName)
        {
            string token = Configuration.Configuration.GetTestData("token"),
                    pageId = Configuration.Configuration.GetTestData("pageId"); ;
            var request = new RestRequest(
               Configuration.Configuration.GetApiRoute("edit"),
               Method.Post);

            request.AddParameter("owner_id", pageId);
            request.AddParameter("post_id",post_id);
            request.AddParameter("message", newText);
            request.AddParameter("attachments",pictureName);
            request.AddParameter("access_token", token);
            request.AddParameter("v", Configuration.Configuration.ApiVersion);
            
            var response = client.Post(request);
            if (!response.IsSuccessful)
            {
                return string.Empty;
            }
            return response.Content;
        }

        public static async Task<string> CommentPostOnWall(int post_id, string commentText)
        {
            string token = Configuration.Configuration.GetTestData("token"),
                    pageId = Configuration.Configuration.GetTestData("pageId"); ;
            var request = new RestRequest(
               Configuration.Configuration.GetApiRoute("commentPost"),
               Method.Post);

            request.AddParameter("owner_id", pageId);
            request.AddParameter("post_id", post_id);
            request.AddParameter("message", commentText);
            request.AddParameter("access_token", token);
            request.AddParameter("v", Configuration.Configuration.ApiVersion);

            var response = client.Post(request);
            if (!response.IsSuccessful)
            {
                return string.Empty;
            }    
            return response.Content;
        }

        public static async Task<bool> IsPostLikedByUser(int post_id, int userId) 
        {
            string token = Configuration.Configuration.GetTestData("token"),
                        pageId = Configuration.Configuration.GetTestData("pageId"); ;
            var request = new RestRequest(
               Configuration.Configuration.GetApiRoute("isPostLiked"),
               Method.Post);

            request.AddParameter("owner_id", pageId);
            request.AddParameter("item_id", post_id);
            request.AddParameter("user_id", userId);
            request.AddParameter("type", "post");
            request.AddParameter("access_token", token);
            request.AddParameter("v", Configuration.Configuration.ApiVersion);

            var response = client.Post(request);
            if (!response.IsSuccessful)
            {
                return false;
            }
            var res = JsonUtil.ReadField(response.Content, new string[] { "response","liked" });
            if (res != PostLiked)
            {
                return false;
            }
            return true;
        }

        public static async Task<string> DeletePostOnWall(int postId)
        {
            string token = Configuration.Configuration.GetTestData("token"),
                    pageId = Configuration.Configuration.GetTestData("pageId"); ;
            var request = new RestRequest(
               Configuration.Configuration.GetApiRoute("deletePost"),
               Method.Post);

            request.AddParameter("owner_id", pageId);
            request.AddParameter("post_id", postId);
            request.AddParameter("access_token", token);
            request.AddParameter("v", Configuration.Configuration.ApiVersion);
            var response = client.Post(request);
            if (!response.IsSuccessful)
            {
                return string.Empty;
            }
            return response.Content;
        }
    }
}
