package seleniumWebdriver;
import aquality.selenium.browser.AqualityServices;
import aquality.selenium.browser.Browser;
import aquality.selenium.elements.interfaces.IElementFactory;
import org.openqa.selenium.Dimension;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
public abstract class BaseTest {
    private static final String DEFAULT_URL = TheInternetPage.LOGIN.getAddress();
    protected final Dimension defaultSize = new Dimension(1024, 768);
    protected final IElementFactory elementFactory;
    protected BaseTest() {
        elementFactory = AqualityServices.getElementFactory();
    }
    @BeforeMethod
    protected void beforeMethod() {
        getBrowser().goTo(DEFAULT_URL);
        getBrowser().setWindowSize(defaultSize.width, defaultSize.height);
        AqualityServices.getBrowser().getDriver().manage().window().maximize();
        if (!AqualityServices.getBrowser().getCurrentUrl().equals("https://userinyerface.com/game.html%20target=")) {
            AqualityServices.getBrowser().goTo("https://userinyerface.com/game.html%20target=");
        }
        AqualityServices.getBrowser().goTo(TheInternetPage.JAVASCRIPT_ALERTS.getAddress());
    }
    @AfterMethod
    public void afterTest() {
        if (AqualityServices.isBrowserStarted()) {
            AqualityServices.getBrowser().quit();
        }
    }
    protected Browser getBrowser() {
        return AqualityServices.getBrowser();
    }
}