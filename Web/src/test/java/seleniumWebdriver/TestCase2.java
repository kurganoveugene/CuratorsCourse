package seleniumWebdriver;
import org.testng.Assert;
import org.testng.annotations.Test;
public class TestCase2 extends BaseTest{
    private final UserinyerfaceForm userinyerfaceForm = new UserinyerfaceForm();
    private final UserinyerfaceForm.HelpForm form4 = userinyerfaceForm.new HelpForm();
    @Test
    public void testHelpWindow(){
        Assert.assertTrue(userinyerfaceForm.state().isDisplayed());
        userinyerfaceForm.clickHereToGoToTHeNextPage();
        form4.skipHelpWindow();
        form4.state().waitForNotDisplayed();
        Assert.assertEquals("help-form is-hidden", form4.attributeFromHelpForm());
    }
}
