package test;

import aquality.selenium.browser.AqualityServices;
import aquality.selenium.browser.Browser;
import aquality.selenium.elements.interfaces.IElementFactory;
import kong.unirest.Unirest;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import utils.UtilsGetConfig;

public abstract class BaseTest {
    protected final IElementFactory elementFactory;

    protected BaseTest() {
        elementFactory = AqualityServices.getElementFactory();
    }

    @BeforeMethod
    protected void beforeMethod() {
        getBrowser().goTo(UtilsGetConfig.getConfig("defaultURL"));
        getBrowser().maximize();
        getBrowser().waitForPageToLoad();
        Unirest.config().connectTimeout(100000);
        Unirest.config().defaultBaseUrl(UtilsGetConfig.getConfig("defaultURLResponse"));
    }

    @AfterMethod
    public void afterTest() {
        if (AqualityServices.isBrowserStarted()) {
            AqualityServices.getBrowser().quit();
        }
    }

    protected void navigate(String url) {
        getBrowser().goTo(url);
    }

    protected Browser getBrowser() {
        return AqualityServices.getBrowser();
    }
}
