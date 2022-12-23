package com.userinyerface.pages;

import aquality.selenium.elements.interfaces.ILink;
import aquality.selenium.forms.Form;
import org.openqa.selenium.By;

public class MainPage extends Form {


    private final ILink linkToGamePage = getElementFactory().getLink(By.xpath("//a[@class='start__link']"), "Please click HERE to GO to the next page");

    public MainPage(){
        super(By.xpath("//div[@class='logo__icon']"), "User Inyerface Logo");
    }

    public void linkClick(){
        linkToGamePage.click();
    }

}
