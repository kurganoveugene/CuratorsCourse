package utils;

import aquality.selenium.core.utilities.ISettingsFile;
import aquality.selenium.core.utilities.JsonSettingsFile;

public class UtilsGetConfig {
    protected static final ISettingsFile config = new JsonSettingsFile("config.json");
    protected static final ISettingsFile configTest = new JsonSettingsFile("configTest.json");

    public static String getConfig(String nameSetting) {
        return config.getValue("/" + nameSetting).toString();
    }

    public static String getConfigTest(String nameSetting) {
        return configTest.getValue("/" + nameSetting).toString();
    }
}
