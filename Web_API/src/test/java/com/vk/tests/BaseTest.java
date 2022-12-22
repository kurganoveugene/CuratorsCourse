package com.vk.tests;

import aquality.selenium.browser.AqualityServices;
import aquality.selenium.browser.Browser;
import com.vk.utils.JsonUtils;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;

public abstract class BaseTest {

    @BeforeMethod
    public void beforeMethod() {
        AqualityServices.getBrowser();
        AqualityServices.getBrowser().getDriver();
        getBrowser().goTo(JsonUtils.getValueFromFile("config.json").getValue("/baseURL").toString());
        AqualityServices.getBrowser().getDriver().manage().window().maximize();
    }

    @AfterMethod
    public void afterTest() {
        if (AqualityServices.isBrowserStarted()) {
            AqualityServices.getBrowser().quit();
        }
    }

    public Browser getBrowser() {
        return AqualityServices.getBrowser();
    }
}