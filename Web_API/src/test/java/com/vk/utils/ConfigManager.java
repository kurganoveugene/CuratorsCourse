package com.vk.utils;

public class ConfigManager {

    public static String getParameterValue(String key) {
        return Environment.getCurrentCurrentJsonFile("config.json").getValue("/" + key).toString();
    }
}
