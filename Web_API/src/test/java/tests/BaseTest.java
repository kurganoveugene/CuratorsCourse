package tests;

import com.vk.HttpClient;
import com.vk.utils.BrowserManager;
import com.vk.utils.ConfigManager;
import org.testng.annotations.AfterTest;
import org.testng.annotations.BeforeTest;

public class BaseTest {

    @BeforeTest
    public void setUp(){
       HttpClient.setDefaultUrl(ConfigManager.getParameterValue("unirestStartUrl"));
       BrowserManager.getBrowser().maximize();
    }

    @AfterTest
    public void tearDown() {
        BrowserManager.getBrowser().quit();
    }
}
