using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using Rest_API.Utils;
using VK_API.Models;
using VK_API.Pages;

namespace VK_API.Tests
{
    public class Tests
    {

        private static ISettingsFile Config => new JsonSettingsFile("config.json");
        private static ISettingsFile Testdata => new JsonSettingsFile("TestData.json");

        [SetUp]
        public void Setup() => AqualityServices.Browser.GoTo(Config.GetValue<string>("BaseUrl"));

        [TearDown]
        public void TearDown() => AqualityServices.Browser.Quit();

        [Test]
        public void Test1()
        {
            var homepage = new HomePage();
            homepage.State.WaitForDisplayed();
            homepage.ClickLogin();
            var loginpage = new LoginPage();
            loginpage.State.WaitForDisplayed();
            loginpage.ClickLoginTextbox();
            loginpage.TypeTextIntoLoginTextbox(Config.GetValue<string>("login"));
            loginpage.ClickContinueButtonPhone();
            loginpage.WaitForPasswordFieldExist();
            loginpage.TypeTextIntoLoginTextbox(Config.GetValue<string>("password"));
            loginpage.ClickContinueButtonPass();
            var feedpage = new FeedPage();
            feedpage.State.WaitForDisplayed();
            feedpage.ClickProfileButton();
            var profilepage = new ProfilePage();
            Assert.True(profilepage.State.WaitForDisplayed(), "Profile page isn't opened");
            var restClient = Client.GetRestClient(Config.GetValue<Uri>("client_API_url"));
            string RandomStringForPost = StringUtils.RandomLatinstringCapital(Config.GetValue<int>("numberOfRandomCharsForStringOnTheWall"));
            Dictionary<string, string> ParamsforWallPost = new Dictionary<string, string>()
            {
                ["owner_id"] = Config.GetValue<string>("owner_id"),
                ["message"] = RandomStringForPost,
                ["access_token"] = Config.GetValue<string>("token"),
                ["v"] = Config.GetValue<string>("API_version")
            };
            var restPostRequest = ApiUtils.CreatePostRequest(Config.GetValue<string>("route_wall_post"), ParamsforWallPost);
            var responsePost = restClient.Execute(restPostRequest);
            var PostContent = ApiUtils.GetContentFromResponse<WallPostResponse>(responsePost);
            profilepage.postID = PostContent.Response.Post_Id;
            string TextFromPost = profilepage.GetTextFromPost();
            Assert.AreEqual(RandomStringForPost, profilepage.GetTextFromPost(), "Posts are not equal");
            Assert.AreEqual(Testdata.GetValue<string>("UserId"), profilepage.GetIdUserWhoPosted(), "Users who post are not the same");
            Dictionary<string, string> getUploadAdress = new Dictionary<string, string>()
            {
                ["group_id"] = Config.GetValue<string>("owner_id"),
                ["access_token"] = Config.GetValue<string>("token"),
                ["v"] = Config.GetValue<string>("API_version")
            };
            var restGetAdressRequest = ApiUtils.CreatePostRequest(Config.GetValue<string>("route_get_adress_for_photo"), getUploadAdress);
            var responseAdress = restClient.Execute(restGetAdressRequest);
            var AdressContent = ApiUtils.GetContentFromResponse<WallUploadPhoto>(responseAdress);

            var clientforUpload = new RestClient();
            var restUploadPhotoRequest = ApiUtils.UploadRequest(AdressContent.Response.Upload_Url, Path.Combine(Directory.GetCurrentDirectory() + Config.GetValue<string>("upload_file_path")));
            var responseUploadPhoto = clientforUpload.Execute(restUploadPhotoRequest);
            var PhotoContent = ApiUtils.GetContentFromResponse<PhotoParameters>(responseUploadPhoto);
            Dictionary<string, string> SavePhotoParams = new Dictionary<string, string>()
            {
                ["server"] = PhotoContent.Server.ToString(),
                ["group_id"] = Config.GetValue<string>("owner_id"),
                ["photo"] = PhotoContent.Photo,
                ["hash"] = PhotoContent.Hash,
                ["access_token"] = Config.GetValue<string>("token"),
                ["v"] = Config.GetValue<string>("API_version")
            };
            var restGetPhotoParams = ApiUtils.CreatePostRequest(Config.GetValue<string>("route_for_save_photo"), SavePhotoParams);
            var responseGetPhotoParams = restClient.Execute(restGetPhotoParams);
            var WallfileParams = ApiUtils.GetContentFromResponse<WallFileParameters>(responseGetPhotoParams);
            string RandomStringForEditPost = StringUtils.RandomLatinstringCapital(Config.GetValue<int>("numberOfRandomCharsForStringOnTheWall"));
            string photoID = "photo" + WallfileParams.Response[0].Owner_Id.ToString() + "_" + WallfileParams.Response[0].Id.ToString();
            Dictionary<string, string> ParamsforEditWallPost = new Dictionary<string, string>()
            {
                ["owner_id"] = Config.GetValue<string>("owner_id"),
                ["post_id"] = profilepage.postID,
                ["message"] = RandomStringForEditPost,
                ["attachments"] = photoID,
                ["access_token"] = Config.GetValue<string>("token"),
                ["v"] = Config.GetValue<string>("API_version")
            };
            var EditPostrequest = ApiUtils.CreatePostRequest(Config.GetValue<string>("route_for_edit_post"), ParamsforEditWallPost);
            var responseUploadPhotoOnWall = restClient.Execute(EditPostrequest);
            string TextFromEditedPost = profilepage.GetTextFromPost();
            Assert.True(profilepage.WaitForImageDisplayed());
            Assert.AreNotEqual(TextFromPost, TextFromEditedPost, "Texts in post are equal");
            Assert.True(profilepage.GetImageIdFromPost().Contains(photoID),"Photo id isn't the same");
            string RandomStringForComment = StringUtils.RandomLatinstringCapital(Config.GetValue<int>("numberOfRandomCharsForStringInComments"));
            Dictionary<string, string> CommentParams = new Dictionary<string, string>()
            {
                ["owner_id"] = Config.GetValue<string>("owner_id"),
                ["post_id"] = profilepage.postID,
                ["message"] = RandomStringForComment,
                ["access_token"] = Config.GetValue<string>("token"),
                ["v"] = Config.GetValue<string>("API_version")
            };
            var CommentRequest = ApiUtils.CreatePostRequest(Config.GetValue<string>("route_for_comment"), CommentParams);
            var responseComment = restClient.Execute(CommentRequest);
            profilepage.ClicktoShowNextCommentButton();
            Assert.AreEqual(Testdata.GetValue<string>("UserId"), profilepage.GetUserIDWhoCommented(), "Users who commented are not the same");
            profilepage.AddLike();

            Dictionary<string, string> LikeParams = new Dictionary<string, string>()
            {
                ["owner_id"] = Config.GetValue<string>("owner_id"),
                ["type"] = "post",
                ["item_id"] = profilepage.postID,
                ["access_token"] = Config.GetValue<string>("token"),
                ["v"] = Config.GetValue<string>("API_version")
            };
            var LikeRequest = ApiUtils.CreatePostRequest(Config.GetValue<string>("route_for_like"), LikeParams);
            var LikeResponse = restClient.Execute(LikeRequest);
            profilepage.WaitForActiveLike();
            var LikeContent = ApiUtils.GetContentFromResponse<LikeResponse>(LikeResponse);
            Assert.AreEqual(Testdata.GetValue<int>("LikePresents"), LikeContent.Response.Liked);

            Dictionary<string, string> DelPostParams = new Dictionary<string, string>()
            {
                ["owner_id"] = Config.GetValue<string>("owner_id"),
                ["post_id"] = profilepage.postID,
                ["access_token"] = Config.GetValue<string>("token"),
                ["v"] = Config.GetValue<string>("API_version")
            };
            var DelPostRequest = ApiUtils.CreatePostRequest(Config.GetValue<string>("route_for_detele"), DelPostParams);
            var DelResponse = restClient.Execute(DelPostRequest);
            Assert.True(profilepage.IsPostDeleted(), "Post isn't deleted");
        }
    }
}