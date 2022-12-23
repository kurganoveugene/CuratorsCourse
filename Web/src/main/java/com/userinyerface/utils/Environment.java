package com.userinyerface.utils;

import aquality.selenium.core.utilities.ISettingsFile;
import aquality.selenium.core.utilities.JsonSettingsFile;
import java.nio.file.Path;
import java.nio.file.Paths;

class Environment {

    private Environment() {
    }

    public static ISettingsFile getCurrentConfig() {
        Path resourcePath = Paths.get("config.json");
        return new JsonSettingsFile(resourcePath.toString());
    }

    public static ISettingsFile getCurrentTestData() {
        Path resourcePath = Paths.get("testData.json");
        return new JsonSettingsFile(resourcePath.toString());
    }

}



