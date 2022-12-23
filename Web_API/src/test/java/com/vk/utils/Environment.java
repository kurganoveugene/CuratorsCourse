package com.vk.utils;

import aquality.selenium.core.utilities.ISettingsFile;
import aquality.selenium.core.utilities.JsonSettingsFile;
import java.nio.file.Path;
import java.nio.file.Paths;

public class Environment {

    public static ISettingsFile getCurrentCurrentJsonFile(String name) {
        Path resourcePath = Paths.get(name);
        return new JsonSettingsFile(resourcePath.toString());
    }
}