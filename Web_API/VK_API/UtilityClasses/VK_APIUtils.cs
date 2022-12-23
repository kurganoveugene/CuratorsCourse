using System;
using System.Linq;
using RestSharp;

namespace VK_API
{
    public static class VK_APIUtils
    {
        private const int returnUserCount = 10;

        public static string WallComment(ConfigData configData, string wallPostId)
        {
            var client = new RestClient(configData.API_URL);
            var request = new RestRequest($"wall.createComment?owner_id={configData.id}&post_id={wallPostId}&from_group=0&message={RandomTextGenerator.Generate(26)}&access_token={configData.token}&v={configData.API_V}");
            request.RequestFormat = DataFormat.Json;
            return new String(client.Post(request).Content.Where(char.IsDigit).ToArray());
        }

        public static WallMessage WallMessagePost(ConfigData configData, string item)
        {
            var client = new RestClient(configData.API_URL);
            var request = new RestRequest($"wall.post?owner_id={configData.id}&friends_only=0&from_group=0&message={item}&access_token={configData.token}&v={configData.API_V}");
            request.RequestFormat = DataFormat.Json;
            WallMessage wallMessage = new();
            wallMessage.messageID = new String(client.Post(request).Content.Where(char.IsDigit).ToArray());
            wallMessage.messageContent = item;
            return wallMessage;
        }

        public static IRestResponse<RootUploadServerResponse> GetWallUploadServer(ConfigData configData)
        {
            var client = new RestClient(configData.API_URL);
            var request = new RestRequest($"photos.getWallUploadServer?user_id={configData.id}&access_token={configData.token}&v={configData.API_V}");
            return client.Get<RootUploadServerResponse>(request);
        }

        public static IRestResponse GetLikes(ConfigData configData, string postId)
        {
            var client = new RestClient(configData.API_URL);
            var request = new RestRequest($"wall.getLikes?owner_id={configData.id}&post_id={postId}&count={returnUserCount}&access_token={configData.token}&v={configData.API_V}");
            return client.Get(request);
        }

        public static IRestResponse DeletePost(ConfigData configData, string postId)
        {
            var client = new RestClient(configData.API_URL);
            var request = new RestRequest($"wall.delete?owner_id={configData.id}&post_id={postId}&access_token={configData.token}&v={configData.API_V}");
            return client.Get(request);
        }

        public static IRestResponse UploadPhoto(string URL, string filePath)
        {
            var client = new RestClient(URL);
            var request = new RestRequest();
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("content-type", "multipart/form-data");
            request.AddFile("photo", filePath);
            return client.Post(request);
        }

        public static IRestResponse<RootSaveWallPhoto> SaveWallPhoto(ConfigData configData, PhotoUploadResponse uploadResponse)
        {
            var client = new RestClient(configData.API_URL);
            var request = new RestRequest($"photos.saveWallPhoto?user_id={configData.id}&photo={uploadResponse.photo}&server={uploadResponse.server}&hash={uploadResponse.hash}&access_token={configData.token}&v={configData.API_V}");
            request.RequestFormat = DataFormat.Json;
            return client.Post<RootSaveWallPhoto>(request);
        }

        public static string EditWallPost(ConfigData configData, SaveWallPhotoData photoData, string wallPostId)
        {
            string newText = RandomTextGenerator.Generate(26);
            var client = new RestClient(configData.API_URL);
            var request = new RestRequest($"wall.edit?owner_id={configData.id}&post_id={wallPostId}&friends_only=0&message={newText}&attachments=photo{photoData.owner_id}_{photoData.id}&access_token={configData.token}&v={configData.API_V}");
            request.RequestFormat = DataFormat.Json;
            client.Post(request);
            return newText;
        }
    }
}
