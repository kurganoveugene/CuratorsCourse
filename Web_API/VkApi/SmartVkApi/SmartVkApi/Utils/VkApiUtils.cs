using SmartVkApi.Configurations;
using RestSharp;
using SmartVkApi.Models;

namespace SmartVkApi.Utils
{
    public class VkApiUtils
    {
        private IRestClient client = new RestClient(Configuration.ApiUrl);

        public PostRespModel PostRequest(string post)
        {
            var request = new RestRequest(post);
            var response = client.Post<PostRespModel>(request);
            return response.Data;
        }

        public LikersModel GetRequest(string expression)
        {
            var request = new RestRequest(expression);
            var response = client.Get<LikersModel>(request);
            return response.Data;
        }
    }
}
