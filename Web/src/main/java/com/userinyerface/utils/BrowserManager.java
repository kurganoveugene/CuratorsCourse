package com.userinyerface.utils;

import aquality.selenium.browser.AqualityServices;
import aquality.selenium.browser.Browser;

public abstract class BrowserManager {

    private static Browser browser = AqualityServices.getBrowser();

    public static Browser getBrowser(){
        return browser;
    }
}
