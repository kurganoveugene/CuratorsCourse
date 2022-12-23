package com.vk.pages;

import aquality.selenium.elements.interfaces.IButton;
import aquality.selenium.elements.interfaces.ITextBox;
import aquality.selenium.forms.Form;
import com.vk.utils.TestDataManager;
import org.openqa.selenium.By;

public class SignInPage extends Form {
    private final IButton signInButton = getElementFactory().getButton(By.id("index_login_button"), "sign in");
    private final ITextBox phoneOrEmailTextBox = getElementFactory().getTextBox(By.xpath("//input[@name='email' and @class='big_text']"), "phone or email");
    private final ITextBox passwordTextBox = getElementFactory().getTextBox(By.xpath("//input[@name='pass' and @class='big_text']"), "password");


    public SignInPage() {
        super(By.id("page_header"), "header");
    }

    public void enterAuthPhoneOrEmailData() {
        phoneOrEmailTextBox.type(TestDataManager.getParameterValue("login"));
    }

    public void enterAuthPasswordData() {
        passwordTextBox.type(TestDataManager.getParameterValue("password"));
    }

    public void clickSignInButton() {
        signInButton.click();
    }

}
