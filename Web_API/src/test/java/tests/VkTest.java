package tests;

import com.vk.forms.LeftSideNavigationBarMenu;
import com.vk.model.*;
import com.vk.pages.MyPage;
import com.vk.pages.SignInPage;
import com.vk.utils.BrowserManager;
import com.vk.utils.TestData;
import com.vk.utils.VKAPIUtils;
import org.testng.Assert;
import org.testng.annotations.Test;
import java.io.UnsupportedEncodingException;

public class VkTest extends BaseTest {

    SignInPage signInPage = new SignInPage();
    LeftSideNavigationBarMenu leftNavBar = new LeftSideNavigationBarMenu();
    MyPage myPage = new MyPage();

    @Test
    public void vkTest() throws UnsupportedEncodingException {

        BrowserManager.getBrowser().goTo(BrowserManager.BASE_URL);
        Assert.assertTrue(signInPage.state().waitForDisplayed(), "Main Page is not open");
        signInPage.enterAuthPhoneOrEmailData();
        signInPage.enterAuthPasswordData();
        signInPage.clickSignInButton();
        leftNavBar.state().waitForDisplayed();
        leftNavBar.clickMyPageButton();
        myPage.state().waitForDisplayed();
        WallSendMessage wallSendMessage = VKAPIUtils.sendWallMessage();
        String post_id = wallSendMessage.getResponse().getPost_id();
        Assert.assertTrue(VKAPIUtils.isIdExist(post_id), "Response field post_id is not exist");
        Assert.assertTrue(myPage.waitForMessageDisplayed(post_id, TestData.RANDOM_STRING), "Post is not published");
        WallSavePhoto editWall = VKAPIUtils.editWallMessageAndAddPhoto(post_id);
        Assert.assertTrue(myPage.waitForMessageDisplayed(post_id, TestData.UPDATE_RANDOM_STRING), "Message is not changed");
        Assert.assertTrue(myPage.isTheSamePhotoAdded(post_id, editWall.getResponse().get(0).getId()), "Photo is not published");
        WallSendComment wallSendComment = VKAPIUtils.sendWallComent(wallSendMessage.getResponse().getPost_id());
        Assert.assertTrue(myPage.isMyCommentAdded(post_id), "Message is not changed");
        myPage.setLike(post_id);
        LikeGetList likeGetList = VKAPIUtils.getLikesList(wallSendComment.getResponse().getComment_id());
        Assert.assertTrue(VKAPIUtils.isTrueLikeOwner(likeGetList.getResponse().getItems().get(0).getId()), "Invalid like_owner");
        VKAPIUtils.wallDeletePost(post_id);
        Assert.assertTrue(myPage.waitForPostNotDisplayed(post_id), "Post is not deleted");
    }
}
