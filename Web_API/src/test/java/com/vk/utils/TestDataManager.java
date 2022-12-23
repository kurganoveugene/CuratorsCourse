package com.vk.utils;

import aquality.selenium.core.logging.Logger;

public class TestDataManager {

    public static String getParameterValue(String key) {
        Logger.getInstance().info("Get parameter " + key + " value");
        return Environment.getCurrentCurrentJsonFile("testData.json").getValue("/" + key).toString();
    }
}