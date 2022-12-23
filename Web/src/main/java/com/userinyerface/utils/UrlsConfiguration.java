package com.userinyerface.utils;

public class UrlsConfiguration {

    public static String getStartUrl() {
        return Environment.getCurrentConfig().getValue("/startUrl").toString();
    }
}


