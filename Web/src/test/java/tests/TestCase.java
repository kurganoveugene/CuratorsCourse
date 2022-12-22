package tests;
import org.testng.Assert;
import org.testng.annotations.Test;
import page.MainPage;
import page.RegisterPage;
import utils.RandomUtil;

public class TestCase extends BaseTest{
    @Test//test case 1
    public void test() {
        MainPage mainPage=new MainPage();
        RegisterPage registerPage=new RegisterPage();
        Assert.assertTrue(mainPage.state().isDisplayed(), "Main Page don't open");
        mainPage.linkStartClick();
        Assert.assertTrue(registerPage.state().isDisplayed(), "Register Page don't open");
        registerPage.getLoginForm().setTextBoxPassword(RandomUtil.getRandomPassword());
        registerPage.getLoginForm().setTextBoxEmail(RandomUtil.getRandomAlphanumericString(3,10));
        registerPage.getLoginForm().setTextBoxDomain(RandomUtil.getRandomAlphanumericString(3,10));
        registerPage.getLoginForm().clickComboBoxDomain();
        registerPage.getLoginForm().clickCheckBoxAccept();
        registerPage.getLoginForm().clickButtonNext();

        Assert.assertTrue(registerPage.getInterestsForm().state().isDisplayed(), "interest form don't open");

        registerPage.getInterestsForm().randomCheckBoxInterest();
        registerPage.getInterestsForm().clickButtonUpload();
    }

/*    public void testAcceptCookies() {
        MainPage mainPage=new MainPage();
        RegisterPage registerPage=new RegisterPage();
        Assert.assertTrue(mainPage.state().isDisplayed(), "Main Page don't open");
        mainPage.linkStartClick();
        Assert.assertTrue(registerPage.state().isDisplayed(), "Register Page don't open");
        registerPage.getCookiesForm().clickButtonNo();
        Assert.assertTrue(!registerPage.getCookiesForm().state().isDisplayed(), "Cookies form don't displayed");
    }*/


/*    public void testHidenHelpForm() {
        MainPage mainPage=new MainPage();
        RegisterPage registerPage=new RegisterPage();
        Assert.assertTrue(mainPage.state().isDisplayed(), "Main Page don't open");
        mainPage.linkStartClick();
        Assert.assertTrue(registerPage.state().isDisplayed(), "Register Page don't open");
        registerPage.getHelpForm().clickButtonSend();
        Assert.assertTrue(!registerPage.getCookiesForm().state().isDisplayed(), "Cookies form don't displayed");
    }*/

/*    public void testTimerZiro() {
        MainPage mainPage=new MainPage();
        RegisterPage registerPage=new RegisterPage();
        Assert.assertTrue(mainPage.state().isDisplayed(), "Main Page don't open");
        mainPage.linkStartClick();
        Assert.assertTrue(registerPage.state().isDisplayed(), "Register Page don't open");
        Assert.assertEquals(registerPage.getTimerText(), "00:00:00", "timer is not 00:00:00");
    }*/
}
