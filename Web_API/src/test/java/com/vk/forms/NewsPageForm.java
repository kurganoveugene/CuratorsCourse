package com.vk.forms;

import aquality.selenium.elements.interfaces.IButton;
import aquality.selenium.forms.Form;
import org.openqa.selenium.By;

public class NewsPageForm extends Form {
    private final String xpathOfMyPageButton = "//li[@id='l_pr']";
    private final IButton myPageButton = getElementFactory().getButton(By.xpath(xpathOfMyPageButton), "My page");
    public NewsPageForm() {
        super(By.xpath("//div[@id='feed_rmenu']"), "News page");
    }

    public void clickMyPageButton(){
        myPageButton.clickAndWait();
    }
}
