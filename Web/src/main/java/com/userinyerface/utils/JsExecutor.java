package com.userinyerface.utils;

import aquality.selenium.core.logging.Logger;
import org.openqa.selenium.WebElement;

public class JsExecutor {

    public static void helpFormDisplayNone(WebElement webElem) {
        Logger.getInstance().info("Help Form :: hide by JS_action");
        BrowserManager.getBrowser().executeScript("arguments[0].style.display='none';", webElem);
    }
}
