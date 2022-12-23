package com.vk.pages;

import aquality.selenium.elements.interfaces.IButton;
import aquality.selenium.elements.interfaces.ILink;
import aquality.selenium.elements.interfaces.ITextBox;
import aquality.selenium.forms.Form;
import com.vk.utils.TestData;
import org.openqa.selenium.By;

public class MyPage extends Form {

    public MyPage() {
        super(By.id("page_header_wrap"), "header");
    }

    public boolean waitForMessageDisplayed(String post_id, String message) {
        ITextBox myMessageTextBox = getElementFactory().getTextBox(By.id(String.format("wpt%s_%s",
                TestData.OWNER_ID, post_id)), "my message");

        return myMessageTextBox.state().waitForDisplayed() &&
                myMessageTextBox.getText().equals(message);
    }

    public boolean isTheSamePhotoAdded(String post_id, String photo_id) {
        ILink myPhotoLink = getElementFactory().getLink(By.xpath(String.format("//div[@id='post%s_%s'] //a[@data-photo-id='%s_%s']",
                TestData.OWNER_ID, post_id, TestData.OWNER_ID, photo_id)), "my Photo");
        myPhotoLink.getJsActions().scrollIntoView();
        return myPhotoLink.state().isDisplayed();
    }

    public boolean isMyCommentAdded(String post_id) {
        IButton showNextCommentButton = getElementFactory().getButton(By.xpath(String.format("//div[@id='post%s_%s'] //span[@class='js-replies_next_label']",
                TestData.OWNER_ID, post_id)), "next comment");

        showNextCommentButton.click();

        ITextBox myCommentTextBox = getElementFactory().getTextBox(By.id(String.format("wpt%s_%s",
                TestData.OWNER_ID, post_id)), "my comment text");

        return myCommentTextBox.state().isDisplayed();
    }

    public void setLike(String post_id) {

        ITextBox commentWrapperTextBox = getElementFactory().getTextBox(By.id(String.format("replies%s_%s",
                TestData.OWNER_ID, post_id)), "Comment wrapper");

        commentWrapperTextBox.getMouseActions().moveMouseToElement();

        IButton likeButton = getElementFactory().getButton(By.xpath(String.format("//div[@id='replies%s_%s']//a[contains(@class, 'like_btn') and contains(@class, '_like')]",
                TestData.OWNER_ID, post_id)), "next comment");
        likeButton.click();
    }

    public boolean waitForPostNotDisplayed(String post_id) {
        ITextBox myPostTextBox = getElementFactory().getTextBox(By.id(String.format("wpt%s_%s",
                TestData.OWNER_ID, post_id)), "my post");

        return myPostTextBox.state().waitForNotDisplayed();
    }
}