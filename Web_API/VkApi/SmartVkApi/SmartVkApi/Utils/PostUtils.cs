using System.Collections.Generic;
using SmartVkApi.Configurations;
using SmartVkApi.Models;

namespace SmartVkApi.Utils
{
    public class PostUtils
    {
        public PostRespModel PushPostAndGetResponse(string message)
        {
            var paramsDict = new Dictionary<string, string> { { "owner_id", Configuration.OwnerId }, { "message", message } };
            var post = new RequestUtils().CreateRequest("wall.post", paramsDict);
            var responseModel = new VkApiUtils().PostRequest(post);
            return responseModel;
        }

        public void DeletePost(string postId)
        {
            var paramsDict = new Dictionary<string, string> {{"owner_id", Configuration.OwnerId}, {"post_id", postId} };
            var deletePostRequest = new RequestUtils().CreateRequest("wall.delete", paramsDict);
            new VkApiUtils().PostRequest(deletePostRequest);
        }
    }
}
