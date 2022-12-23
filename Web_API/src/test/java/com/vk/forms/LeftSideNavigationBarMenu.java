package com.vk.forms;

import aquality.selenium.elements.interfaces.IButton;
import aquality.selenium.forms.Form;
import org.openqa.selenium.By;

public class LeftSideNavigationBarMenu extends Form {

    private final IButton myPageButton = getElementFactory().getButton(By.xpath("//li[@id='l_pr']//following-sibling::span[@class='left_label inl_bl']"), "my page");

    public LeftSideNavigationBarMenu(){
        super(By.className("side_bar_nav"), "left navigation bar menu");
    }

    public void clickMyPageButton(){
        myPageButton.click();
    }


}
