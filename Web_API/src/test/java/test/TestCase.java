package test;

import Pages.LoginPage;
import Pages.MainPage;
import Pages.MyPage;
import aquality.selenium.core.logging.Logger;
import enam.Wall;
import models.Post;
import models.Response;
import org.testng.Assert;
import org.testng.annotations.Test;
import utils.*;

import java.util.List;

public class TestCase extends BaseTest {

    @Test
    public void test() {
        Post myPost = new Post();
        Post myComment = new Post();
        List<Post> listPosts;
        List<Post> listComments;
        LoginPage loginPage = new LoginPage();
        MainPage mainPage = new MainPage();
        MyPage myPage = new MyPage();
        Logger.getInstance().info("step 1");
        Assert.assertTrue(loginPage.state().isDisplayed(), "Login form don't open");
        Logger.getInstance().info("step 2");
        loginPage.getLoginForm().setTextBoxEmail(UtilsGetConfig.getConfig("login"));
        loginPage.getLoginForm().setTextBoxPassword(UtilsGetConfig.getConfig("password"));
        loginPage.getLoginForm().clickButtonEnter();
        Logger.getInstance().info("step 3");
        mainPage.getLeftUserMenu().state().waitForDisplayed();
        Assert.assertTrue(mainPage.getLeftUserMenu().state().isDisplayed(), "Left user menu don't open");
        mainPage.getLeftUserMenu().clickButtonMyPage();
        myPage.state().waitForDisplayed();
        Assert.assertTrue(myPage.state().isDisplayed(), "My page don't open");
        Logger.getInstance().info("step 4");
        UtilModel.fillMyPost(myPost);
        myPost.setIdPost(UtilsResponse.getId(APIUtils.postResponse(Wall.POST, APIUtils.createMapNewPost(myPost.getMessage()))));
        Logger.getInstance().info("step 5");
        listPosts = myPage.getPostForm().GetPosts();
        Assert.assertTrue(UtilsCheck.checkPost(listPosts, myPost), "My post  don't added");
        Logger.getInstance().info("step 6");
        myPost.setMessage(UtilsRandom.getRandomAlphanumericString());
        String url = UtilsResponse.getUrl(APIUtils.postResponse(Wall.GET_UPLOAD_SERVER, APIUtils.createMapUploadServer()));
        Response responseUploadAttribute = UtilsResponse.getResponseUploadAttribute(APIUtils.uploadPhoto(url));
        myPost.setIdImage(UtilsResponse.getMediaId(APIUtils.postResponse(Wall.PHOTOS_SAVE, APIUtils.createMapPhotoSave(responseUploadAttribute))));
        APIUtils.getResponse(Wall.EDIT, APIUtils.createMapEditPost(myPost, myPost.getMessage()));
        Logger.getInstance().info("step 7");
        listPosts = myPage.getPostForm().GetPosts();
        Assert.assertTrue(UtilsCheck.checkPost(listPosts, myPost), "My post  don't edit");
        Logger.getInstance().info("step 8");
        UtilModel.fillMyPost(myComment);
        myComment.setIdPost(UtilsResponse.getCommentId(APIUtils.getResponse(Wall.CREATE_COMMENT, APIUtils.createMapComment(myPost.getIdPost(), myComment.getMessage()))));
        Logger.getInstance().info("step 9");
        listComments = myPage.getPostForm().getComments(myPost);
        Assert.assertTrue(UtilsCheck.checkPost(listComments, myComment), "My comment in post  don't added");
        Logger.getInstance().info("step 10");
        myPage.getPostForm().clickLike(myPost);
        Logger.getInstance().info("step 11");
        Assert.assertTrue(UtilsResponse.getCount(APIUtils.postResponse(Wall.GET_LIKES, APIUtils.createMapGetLikes(myPost.getIdPost()))) > 0, "likes don't added");
        Logger.getInstance().info("step 12");
        APIUtils.getResponse(Wall.DELETE, APIUtils.createMapDelete(myPost.getIdPost()));
        Logger.getInstance().info("step 13");
        listPosts = myPage.getPostForm().GetPosts();
        Assert.assertFalse(UtilsCheck.checkPost(listPosts, myPost), "My post  don't delete");
    }
}
