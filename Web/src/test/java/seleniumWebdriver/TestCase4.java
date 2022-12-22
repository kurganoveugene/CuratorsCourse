package seleniumWebdriver;
import org.testng.Assert;
import org.testng.annotations.Test;
public class TestCase4 extends BaseTest{
    private final UserinyerfaceForm userinyerfaceForm = new UserinyerfaceForm();
    private final UserinyerfaceForm.TimerForm timerForm = userinyerfaceForm.new TimerForm();
    @Test
    public void testTimer() {
        Assert.assertTrue(userinyerfaceForm.state().isDisplayed());
        userinyerfaceForm.clickHereToGoToTHeNextPage();
        timerForm.refreshPage();
        Assert.assertEquals("00:00:00", timerForm.getTimerTime());
    }
}
