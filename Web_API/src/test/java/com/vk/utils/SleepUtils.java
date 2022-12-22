package com.vk.utils;

import aquality.selenium.browser.AqualityServices;

public class SleepUtils {
    public static void sleep(Integer timeOfWait){
        try {
            Thread.sleep(timeOfWait);
        } catch (InterruptedException e) {
            AqualityServices.getLogger().error(String.valueOf(e));
        }
    }
}
