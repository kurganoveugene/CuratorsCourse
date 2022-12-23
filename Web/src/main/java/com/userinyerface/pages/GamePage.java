package com.userinyerface.pages;

import aquality.selenium.elements.interfaces.IButton;
import aquality.selenium.elements.interfaces.ITextBox;
import aquality.selenium.forms.Form;
import com.userinyerface.utils.BrowserManager;
import com.userinyerface.utils.JsExecutor;
import org.openqa.selenium.By;

public class GamePage extends Form {

    private final String X_PATH_TO_HELP_FORM = "//div[@class='help-form']";

    private final ITextBox timerDiv = getElementFactory().getTextBox(By.xpath("//div[@class='timer timer--white timer--center']"), "Div help form");
    private final ITextBox helpForm = getElementFactory().getTextBox(By.xpath(X_PATH_TO_HELP_FORM), "Div help form");
    private final ITextBox formCoockies = getElementFactory().getTextBox(By.xpath("//div[@class='cookies']"), "Form Coockies");
    private final IButton hideHelpFormBtn = getElementFactory().getButton(By.xpath("//button[@class='button button--solid button--blue help-form__send-to-bottom-button']"), "Hide Help Form button");
    private final IButton coockiesBtn = getElementFactory().getButton(By.xpath("//button[@class='cookies__button button button--solid button--white']"), "Accept coockies button");


    public GamePage(){
        super(By.xpath("//div[@class='logo__icon']"), "User Inyerface Logo");
    }

    public void hideHelpFormByJs(){
        helpForm.state().waitForDisplayed();
        JsExecutor.helpFormDisplayNone(BrowserManager.getBrowser().getDriver().findElement(By.xpath(X_PATH_TO_HELP_FORM)));
    }

    public void hideHelpFormBySelenium(){
        hideHelpFormBtn.state().waitForClickable();
        hideHelpFormBtn.click();
    }

    public boolean isHelpFormHidden(){
        helpForm.state().waitForNotDisplayed();
        return !helpForm.state().isDisplayed();
    }

    public void acceptCoockiesBtnClick(){
        coockiesBtn.state().waitForClickable();
        coockiesBtn.click();
    }

    public boolean isCoockiesFormClose(){
        return !formCoockies.state().isDisplayed();
    }

    public String getStartTime(){
        return timerDiv.getText();
    }
}







