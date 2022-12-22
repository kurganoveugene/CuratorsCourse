package seleniumWebdriver;
import org.testng.Assert;
import org.testng.annotations.Test;
public class TestCase1 extends BaseTest{
    private final UserinyerfaceForm userinyerfaceForm = new UserinyerfaceForm();
    private final UserinyerfaceForm.FirstAuthorizationForm firstauthorizationForm = userinyerfaceForm.new FirstAuthorizationForm();
    private final UserinyerfaceForm.SecondAuthorizationForm secondAuthorizationForm = userinyerfaceForm.new SecondAuthorizationForm();
    private final UserinyerfaceForm.ThirdAuthorizationForm thirdAuthorizationForm = userinyerfaceForm.new ThirdAuthorizationForm();
    @Test
    public void testAutorization(){
           Assert.assertTrue(userinyerfaceForm.state().isDisplayed());
           userinyerfaceForm.clickHereToGoToTHeNextPage();
           Assert.assertTrue(firstauthorizationForm.state().isDisplayed());
           firstauthorizationForm.acceptingTheTermsOfUse();
           firstauthorizationForm.inputEmail();
           firstauthorizationForm.inputPassword();
           firstauthorizationForm.inputDomain();
           firstauthorizationForm.clickDropdownOpener();
           firstauthorizationForm.clickNextButton();
           Assert.assertTrue(secondAuthorizationForm.state().isDisplayed());
           secondAuthorizationForm.downloadImage();
           secondAuthorizationForm.selectedThreeCheckBoxes();
           secondAuthorizationForm.doubleClickNextButton();
           Assert.assertTrue(thirdAuthorizationForm.state().isDisplayed());
    }
}
