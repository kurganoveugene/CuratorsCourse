using System.Collections.Generic;
using SmartVkApi.Models;
using SmartVkApi.Configurations;

namespace SmartVkApi.Utils
{
    public class LikeUtils
    {
        public LikersModel GetLikersModel(string postId)
        {
            var paramsDict = new Dictionary<string, string> { { "type", "post" }, { "owner_id", Configuration.OwnerId }, { "item_id", postId } };
            var getLikersRequest = new RequestUtils().CreateRequest("likes.getList", paramsDict);
            var response = new VkApiUtils().GetRequest(getLikersRequest);
            return response;
        }
    }
}
