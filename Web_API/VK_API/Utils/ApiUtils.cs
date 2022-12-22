using Newtonsoft.Json;
using Rest_API.Enums;

namespace Rest_API.Utils
{
    public static class ApiUtils
    {

        public static RestRequest CreatePostRequest(string endpoint, Dictionary<String, String> Params)
        {
            var restRequest = new RestRequest(endpoint, Method.Post);
            foreach (var param in Params) restRequest.AddParameter(param.Key, param.Value);
            return restRequest;
        }

        public static T? GetContentFromResponse<T>(RestResponse response)
        {
            var content = response.Content;
            var data = JsonConvert.DeserializeObject<T>(content);
            return data;
        }

        public static RestRequest UploadRequest(string adress, string path)
        {
            var requestUpload = new RestRequest(adress, Method.Post);
            requestUpload.AddHeader("Content-Type", ContentType.Formdata);
            requestUpload.AddFile("photo", path);
            return requestUpload;
        }
    }  
}