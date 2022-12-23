package com.userinyerface.utils;

public class TestDataConfiguration {

    public static String getParameterValue(String key) {
        return Environment.getCurrentTestData().getValue(key).toString();
    }
}
