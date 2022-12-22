package com.vk.forms;

import aquality.selenium.browser.AqualityServices;
import aquality.selenium.forms.Form;
import com.vk.utils.JsonUtils;
import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;

public class MyPageForm extends Form {
    private Integer postID;
    private Post post = new Post();

    public MyPageForm(Integer postID) {
        super(By.xpath("//span[@class='current_info']"), "My page");
        this.postID = postID;
    }

    public Post getPost(){
        return this.post;
    }

        public void clickLike(){
            post.findLike(postID).click();
        }

        public String photoID(){
        return post.findPhoto(postID).getAttribute(JsonUtils.getValueFromFile("config.json").getValue("/dataPhotoId").toString());
        }


        public String textFromPost(){
        return post.getPosts(postID).getText();
        }

        public String authorOfPost(){
            return post.getPosts(postID).getAttribute(JsonUtils.getValueFromFile("config.json").getValue("/id").toString());
        }

        public String authorOfComment(){
            return post.getComment(postID).getAttribute(JsonUtils.getValueFromFile("config.json").getValue("/id").toString());
        }

        public String textFromComment(){
            return post.getComment(postID).getText();
       }

        public boolean checkDelete(){
           return post.getPosts(postID).isDisplayed();
        }

    public class Post extends Form {

        public Post() {
            super(By.xpath("//span[@class='PostHeaderActionsButtonMoreIcon']"), "edit post button");
        }

        public WebElement getPosts(Integer postID){
            return AqualityServices.getBrowser().getDriver().findElement(By.xpath("//div[@id='post627657327_"+postID+"']//div[contains(@class,'_wall_post_cont')]"));
        }

        public WebElement getComment(Integer postID){
            return AqualityServices.getBrowser().getDriver().findElement(By.xpath("//div[@id='post627657327_"+postID+"']//div[@class='reply_text']//div"));
        }

        public WebElement findPhoto(Integer postID){
            return AqualityServices.getBrowser().getDriver().findElement(By.xpath("//div[@id='post627657327_"+postID+"']//div[contains(@class,'_wall_post_cont')]//a"));
        }

        public WebElement findLike(Integer postID){
            return AqualityServices.getBrowser().getDriver().findElement(By.xpath("//div[@id='post627657327_"+postID+"']//a[contains(@class,'_like')]"));
        }
    }

}
