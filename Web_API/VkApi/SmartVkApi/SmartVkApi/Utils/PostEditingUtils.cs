using System.Collections.Generic;
using SmartVkApi.Configurations;

namespace SmartVkApi.Utils
{
    public class PostEditiongUtils
    {
        public void EditPost(string postId, string message)
        {
            var paramsDict = new Dictionary<string, string> {{"owner_id", Configuration.OwnerId}, {"post_id", postId},
                {"message", message}, {"attachments", $"photo{Configuration.OwnerId}_{Configuration.MediaId}"}};
            var edition = new RequestUtils().CreateRequest("wall.edit", paramsDict);
            new VkApiUtils().PostRequest(edition);
        }
    }
}
