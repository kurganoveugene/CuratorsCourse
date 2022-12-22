package seleniumWebdriver;
import org.testng.Assert;
import org.testng.annotations.Test;
public class TestCase3 extends BaseTest{
    private final UserinyerfaceForm userinyerfaceForm = new UserinyerfaceForm();
    private final UserinyerfaceForm.CookiesForm cookiesForm = userinyerfaceForm.new CookiesForm();
    @Test
    public void testCookies() {
        Assert.assertTrue(userinyerfaceForm.state().isDisplayed());
        userinyerfaceForm.clickHereToGoToTHeNextPage();
        cookiesForm.state().waitForDisplayed();
        cookiesForm.acceptTheUseOfCookies();
        Assert.assertEquals(false, cookiesForm.state().isDisplayed());
    }
}
