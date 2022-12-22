package com.vk.tests;

import com.vk.api.models.APIPhotoModel;
import com.vk.api.models.APIPostModel;
import com.vk.api.models.APIUploadServerModel;
import com.vk.forms.AutorizationForm;
import com.vk.forms.MyPageForm;
import com.vk.forms.NewsPageForm;
import com.vk.utils.*;
import kong.unirest.HttpResponse;
import kong.unirest.JsonNode;
import org.testng.Assert;
import org.testng.annotations.Test;
import java.io.File;
import java.util.Map;

public class TestCase1 extends BaseTest {
    private AutorizationForm autorizationForm = new AutorizationForm();
    private NewsPageForm newsPage = new NewsPageForm();
    private VK_APIUtils vk_apiUtils = new VK_APIUtils(JsonUtils.getValueFromFile("config.json").getValue("/accessToken").toString(),
            JsonUtils.getValueFromFile("config.json").getValue("/userID").toString());
    private final int timeOfSleep = 1000;
    private final int lengthOfRandomText = 10;
    private final int differenceBetweenPostIDAndCommentID = 1;
    private final String randomText = RandomUtils.randomString(lengthOfRandomText);
    private final String randomNewText = RandomUtils.randomString(lengthOfRandomText);
    private final String randomCommentText = RandomUtils.randomString(lengthOfRandomText);
    private final File photoToUpload = FileUtils.convertFile(JsonUtils.getValueFromFile("config.json").getValue("/pathToFile").toString(),
            JsonUtils.getValueFromFile("config.json").getValue("/fileName").toString(), JsonUtils.getValueFromFile("config.json").getValue("/fileSuffix").toString());
    private File[] valueArray = {photoToUpload};
    private String[] keyArray ={JsonUtils.getValueFromFile("config.json").getValue("/keyPhoto").toString()};
    private Map<String, Object> valuesMap = MapUtils.getMap(keyArray, valueArray);
    private HttpResponse<APIPostModel> createPostApi = vk_apiUtils.createPost(randomText);
    private HttpResponse<APIUploadServerModel> getWallUploadServerApi = vk_apiUtils.getWallUploadServer();
    private HttpResponse<APIPhotoModel> fileTransferApi = vk_apiUtils.fileTransfer(getWallUploadServerApi.getBody().getUploadUrl(), valuesMap);
    private HttpResponse<JsonNode> saveUploadPhotoApi = vk_apiUtils.saveUploadPhoto(fileTransferApi.getBody().getServer(), fileTransferApi.getBody().getPhoto(),
            fileTransferApi.getBody().getHash());
    private MyPageForm myPageForm = new MyPageForm(Integer.parseInt(createPostApi.getBody().getPost_id()));
    private int commentID = Integer.parseInt(createPostApi.getBody().getPost_id())+ differenceBetweenPostIDAndCommentID;
    private final String photoID = JsonUtils.getValueFromJsonArray(saveUploadPhotoApi.getBody().toString(),
            JsonUtils.getValueFromFile("config.json").getValue("/jsonArrayName").toString(),
            JsonUtils.getValueFromFile("config.json").getValue("/id").toString());

    @Test
    public void testAutorization() {
        autorizationForm.inputEmailOrPhone(JsonUtils.getValueFromFile("config.json").getValue("/emailOrPhone").toString());
        autorizationForm.inputPassword(JsonUtils.getValueFromFile("config.json").getValue("/password").toString());
        autorizationForm.clickSignInButton();
        newsPage.clickMyPageButton();
        Assert.assertEquals(randomText, myPageForm.textFromPost(), "post text is incorrect");
        Assert.assertEquals(String.format("%s%s%s%s",JsonUtils.getValueFromFile("testData.json").getValue("/wpt").toString(),
                        JsonUtils.getValueFromFile("config.json").getValue("/userID").toString(), "_",createPostApi.getBody().getPost_id()),
                        myPageForm.authorOfPost(), "the author of the post is incorrect");
        vk_apiUtils.editPost(createPostApi.getBody().getPost_id(), randomNewText, photoID);
        SleepUtils.sleep(timeOfSleep);
        Assert.assertEquals(randomNewText, myPageForm.textFromPost(), "post text is incorrect");
        Assert.assertEquals(String.format("%s%s%s", JsonUtils.getValueFromFile("config.json").getValue("/userID").toString(),
                "_",photoID), myPageForm.photoID(), "Photo incorrect");
        vk_apiUtils.createComment(createPostApi.getBody().getPost_id(), randomCommentText);
        SleepUtils.sleep(timeOfSleep);
        Assert.assertEquals(String.format("%s%s%s%s",JsonUtils.getValueFromFile("testData.json").getValue("/wpt").toString(),
                JsonUtils.getValueFromFile("config.json").getValue("/userID").toString(), "_", commentID),
                myPageForm.authorOfComment(),"the author of the comment is incorrect");
        Assert.assertEquals(randomCommentText, myPageForm.textFromComment(),"the comment text is incorrect");
        myPageForm.clickLike();
        SleepUtils.sleep(timeOfSleep);
        Assert.assertEquals(JsonUtils.getValueFromFile("testData.json").getValue("/isLikedMethodResponse").toString(),
                vk_apiUtils.requestLikesIsLiked(createPostApi.getBody().getPost_id()).getBody().getLiked(),"no like");
        vk_apiUtils.deletePost(createPostApi.getBody().getPost_id());
        SleepUtils.sleep(timeOfSleep);
        Assert.assertFalse(myPageForm.checkDelete(), "post not deleted");
        FileUtils.deleteFile(photoToUpload);
    }
}

























