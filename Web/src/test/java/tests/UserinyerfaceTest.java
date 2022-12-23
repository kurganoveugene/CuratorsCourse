package tests;

import com.userinyerface.forms.gamepage.AuthorizationForm;
import com.userinyerface.forms.gamepage.UpLoadFileForm;
import com.userinyerface.pages.MainPage;
import com.userinyerface.pages.GamePage;
import com.userinyerface.utils.*;
import org.testng.Assert;
import org.testng.annotations.Test;

public class UserinyerfaceTest extends BaseTest {

    MainPage mainPage = new MainPage();
    GamePage gamePage = new GamePage();
    AuthorizationForm authForm = new AuthorizationForm();
    UpLoadFileForm upLoadFileForm = new UpLoadFileForm();

    @Test
    public void formsTest() {

        // Open Main Page
        BrowserManager.getBrowser().goTo(UrlsConfiguration.getStartUrl());
        // Check if Main Page is open
        Assert.assertTrue(mainPage.state().waitForDisplayed(), "Main Page is not open");
        // Click 'Please click HERE to GO to the next page'
        mainPage.linkClick();
        /////////////////////////////////////// Start test of AuthorizationForm
        // Wait for Game page opening
        gamePage.state().waitForDisplayed();
        // Check if Auth Form is open
        Assert.assertTrue(authForm.state().waitForDisplayed(), "Auth form is not open");
        // Get random password. Set string: [Upcase.length, lowercase.length, 1 Cyr. letter, 1 Digit]
        String fillPassword = DataMathWork.getRandomStringValue(4);
        // Data fill of password field
        authForm.fillDataPasswordField(fillPassword);
        // Data fill of mail field
        authForm.fillDataEmailField(DataMathWork.getRandomStringValue(4) + fillPassword.charAt(0));
        // CheckBox accept Terms & Conditions click
        authForm.checkBoxClick();
        // Data fill of domain field
        authForm.fillDataDomainField("mail.ru");
        // Select option from Drop List
        authForm.selectItemFromdropList();
        // Click Next button
        authForm.btnNextClick();
        /////////////////////////////////////// Start test of UpLoadFileForm
        // Check if upLoadFile Form is open
        Assert.assertTrue(upLoadFileForm.state().waitForDisplayed(), "Upload file form is not open");
        // Scroll into form view and unselect all checkbox click
        upLoadFileForm.unselectAllClick();
        // Select checkBoxes
        upLoadFileForm.selectInterestsElement(3);
        // Click upload button
        upLoadFileForm.uploadFile();
        // Upload file through Robot
        RobotWork.uploadFile(FilePathManager.getAbsolutePath(TestDataConfiguration.getParameterValue("/uploadImage")));
    }

    @Test
    public void hideFormHelp_version1_By_Js() {
        // Open Main Page
        BrowserManager.getBrowser().goTo(UrlsConfiguration.getStartUrl());
        // Check if Main Page is open
        Assert.assertTrue(mainPage.state().waitForDisplayed(), "Main Page is not open");
        // Click 'Please click HERE to GO to the next page'
        mainPage.linkClick();
        // Wait for Game page opening
        gamePage.state().waitForDisplayed();
        // Hide Help Form by js action
        gamePage.hideHelpFormByJs();
        // Check if Help Form is hidden
        Assert.assertTrue(gamePage.isHelpFormHidden(), "Help Form is not hidden");
    }

    @Test
    public void hideFormHelp_version2_By_Selenium() {
        // Open Main Page
        BrowserManager.getBrowser().goTo(UrlsConfiguration.getStartUrl());
        // Check if Main Page is open
        Assert.assertTrue(mainPage.state().waitForDisplayed(), "Main Page is not open");
        // Click 'Please click HERE to GO to the next page'
        mainPage.linkClick();
        // Wait for Game page opening
        gamePage.state().waitForDisplayed();
        // Click Send to Bottom on Help Form
        gamePage.hideHelpFormBySelenium();
        // Check if Help Form is hidden
        Assert.assertTrue(gamePage.isHelpFormHidden(), "Help Form is not hidden");
    }

    @Test
    public void acceptCoockies() {
        // Open Main Page
        BrowserManager.getBrowser().goTo(UrlsConfiguration.getStartUrl());
        // Check if Main Page is open
        Assert.assertTrue(mainPage.state().waitForDisplayed(), "Main Page is not open");
        // Click 'Please click HERE to GO to the next page'
        mainPage.linkClick();
        // Wait for Game page opening
        gamePage.state().waitForDisplayed();
        // Click accept coocies button
        gamePage.acceptCoockiesBtnClick();
        // Check if Coockies Form is close
        Assert.assertTrue(gamePage.isCoockiesFormClose(), "Coockies form must be close after accept action. It stays open");
    }

    @Test
    public void timerStartZero() {
        // Open Main Page
        BrowserManager.getBrowser().goTo(UrlsConfiguration.getStartUrl());
        // Check if Main Page is open
        Assert.assertTrue(mainPage.state().waitForDisplayed(), "Main Page is not open");
        // Click 'Please click HERE to GO to the next page'
        mainPage.linkClick();
        // Wait for Game page opening
        gamePage.state().waitForDisplayed();
        // Start time equals
        Assert.assertEquals(gamePage.getStartTime(), "00:00:00", "Time does not get start from zero");
    }
}
