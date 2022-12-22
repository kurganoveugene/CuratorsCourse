package com.vk.forms;

import aquality.selenium.elements.interfaces.IButton;
import aquality.selenium.elements.interfaces.ITextBox;
import aquality.selenium.forms.Form;
import org.openqa.selenium.By;

public class AutorizationForm extends Form {
    private final String xpathOftxbEmailOrPhone = "//input[@id='index_email']";
    private final String xpathOftxbPassword = "//input[@id='index_pass']";
    private final String xpathOfSignInButton = "//button[@id='index_login_button']";
    private final ITextBox txbEmailOrPhone = getElementFactory().getTextBox(By.xpath(xpathOftxbEmailOrPhone), "Email ot phone");
    private final ITextBox txbPassword = getElementFactory().getTextBox(By.xpath(xpathOftxbPassword), "Password");
    private final IButton signInButton = getElementFactory().getButton(By.xpath(xpathOfSignInButton), "Sign in");

    public AutorizationForm() {
        super(By.xpath("//div[@class='JoinForm__in']"), "JoinForm");
    }
    public void inputEmailOrPhone(String phone){
        txbEmailOrPhone.clearAndTypeSecret(phone);
    }

    public void inputPassword(String password){
        txbPassword.clearAndTypeSecret(password);
    }

    public void clickSignInButton(){
        signInButton.clickAndWait();
    }

}
