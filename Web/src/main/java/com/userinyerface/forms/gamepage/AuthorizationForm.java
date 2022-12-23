package com.userinyerface.forms.gamepage;

import aquality.selenium.elements.interfaces.IButton;
import aquality.selenium.elements.interfaces.ICheckBox;
import aquality.selenium.elements.interfaces.ITextBox;
import aquality.selenium.forms.Form;
import org.openqa.selenium.By;

public class AuthorizationForm extends Form {

    private final ITextBox password = getElementFactory().getTextBox(By.xpath("//input[@placeholder='Choose Password']"), "Input password field");
    private final ITextBox email = getElementFactory().getTextBox(By.xpath("//input[@placeholder='Your email']"), "Input email field");
    private final ITextBox domainInput = getElementFactory().getTextBox(By.xpath("//input[@placeholder='Domain']"), "Input domain field");
    private final ICheckBox termAndConditionsCheckBox = getElementFactory().getCheckBox(By.xpath("//span[@class='icon icon-check checkbox__check']"), "CheckBox accept Terms & Conditions");
    private final IButton btnDropListForm1 = getElementFactory().getButton(By.xpath("//div[@class='dropdown__header']"), "Drop list button form1");
    private final IButton btnOrgFromSubMenuOfDropListForm1 = getElementFactory().getButton(By.xpath("//div[@class='dropdown__list-item' and text()='.org']"), "button Org of Drop List form1");
    private final IButton btnNextForm1 = getElementFactory().getButton(By.xpath("//a[@class='button--secondary' and text()='Next']"), "button Org of Drop List form1");


    public AuthorizationForm() {
        super(By.xpath("//div[@class='login-form__section login-form__fields']"), "Authorization form");
    }

    public void fillDataPasswordField(String data){
        password.click();
        password.clearAndType(data);
    }

    public void fillDataEmailField(String data){
        email.click();
        email.clearAndType(data);
    }

    public void checkBoxClick(){
        termAndConditionsCheckBox.click();
    }

    public void fillDataDomainField(String data){
        domainInput.click();
        domainInput.clearAndType(data);
    }

    public void selectItemFromdropList(){
        btnDropListForm1.state().waitForClickable();
        btnDropListForm1.click();
        btnOrgFromSubMenuOfDropListForm1.state().waitForClickable();
        btnOrgFromSubMenuOfDropListForm1.click();
    }

    public void btnNextClick(){
        btnNextForm1.state().waitForClickable();
        btnNextForm1.click();
    }
 }

