package com.vk.utils;

import aquality.selenium.browser.AqualityServices;
import aquality.selenium.browser.Browser;

public abstract class BrowserManager {

    public static final String BASE_URL = ConfigManager.getParameterValue("seleniumStartUrl");

    private static Browser browser = AqualityServices.getBrowser();

    public static Browser getBrowser() {
        return browser;
    }
}