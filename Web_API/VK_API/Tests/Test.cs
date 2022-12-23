using Aquality.Selenium.Browsers;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace VK_API
{
    public class Test
    {

        private const string TestDataFilePath = @"\Resources\testdata.json";
        private const string ConfigFilePath = @"\Resources\Config.json";

        [SetUp]
        public void Setup()
        {
            AqualityServices.Browser.Maximize();
        }

        [Test]
        public void Test1()
        {
            var configData = DataReader.LoadData<ConfigData>(ConfigFilePath);
            var testData = DataReader.LoadData<TestData>(TestDataFilePath);
            AqualityServices.Browser.GoTo(configData.URL);
            AqualityServices.Browser.WaitForPageToLoad();
            StartPage startPage = new();
            startPage.AutorisationForm.UserAutorisation(testData.password, testData.login);
            FeedPage feedPage = new();
            feedPage.NavigationForm.GoToProfile();
            ProfilePage profilePage = new();
            var wallPost = VK_APIUtils.WallMessagePost(configData, RandomTextGenerator.Generate(25));
            Assert.IsTrue(profilePage.WallForm.IsPostExist(configData.id, wallPost.messageID), "Wall post is not diaplayed ");
            IRestResponse<RootUploadServerResponse> uploadServer = VK_APIUtils.GetWallUploadServer(configData);
            PhotoUploadResponse uploadedPhotoData = JsonConvert.DeserializeObject<PhotoUploadResponse>(VK_APIUtils.UploadPhoto(uploadServer.Data.response[0].upload_url, testData.filePath).Content);
            var savedPhoto = VK_APIUtils.SaveWallPhoto(configData, uploadedPhotoData);
            VK_APIUtils.EditWallPost(configData, savedPhoto.Data.response[0], wallPost.messageID);
            Assert.IsTrue(profilePage.WallForm.IsPictureExists(configData.id, wallPost.messageID, savedPhoto.Data.response[0].owner_id, savedPhoto.Data.response[0].id), "Picture is not present");
            Assert.AreNotEqual(wallPost.messageContent, profilePage.WallForm.GetNewPostMessage(configData.id, wallPost.messageID), "Message of original wall post was not altered");
            var commentId = VK_APIUtils.WallComment(configData, wallPost.messageID);
            AqualityServices.Browser.ScrollWindowBy(0, 300);
            profilePage.WallForm.ClickShowComments(configData.id, wallPost.messageID);
            Assert.IsTrue(profilePage.WallForm.IsCommentExists(configData.id, commentId), "Comment does not exist");
            profilePage.WallForm.ClickLike(configData.id, wallPost.messageID);
            Assert.IsTrue(VK_APIUtils.GetLikes(configData, wallPost.messageID).Content.Contains(configData.id),"Appropriate user didn't liked the post");
            VK_APIUtils.DeletePost(configData, wallPost.messageID);
            Assert.IsTrue(profilePage.WallForm.IsPostDeleted(configData.id, wallPost.messageID));
        }

        [TearDown]
        public void TearDown()
        {
            AqualityServices.Browser.Quit();
        }

    }
}