using System.Collections.Generic;
using SmartVkApi.Configurations;

namespace SmartVkApi.Utils
{
    public class CommentUtils
    {
        public void PushComment(string postId, string message)
        {
            var paramsDict = new Dictionary<string, string> { { "owner_id", Configuration.OwnerId },
                { "post_id", postId.ToString() }, { "message", message } };
            var comment = new RequestUtils().CreateRequest("wall.createComment", paramsDict);
            new VkApiUtils().PostRequest(comment);
        }
    }
}
