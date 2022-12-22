package Pages;

import aquality.selenium.forms.Form;
import forms.LeftUserMenuForm;
import forms.PostForm;
import org.openqa.selenium.By;

public class MyPage extends Form {
    LeftUserMenuForm leftUserMenuForm = new LeftUserMenuForm();
    PostForm postForm = new PostForm();

    public MyPage() {
        super(By.id("profile_short"), "My page");
    }

    public LeftUserMenuForm getLeftUserMenu() {
        return leftUserMenuForm;
    }

    public PostForm getPostForm() {
        return postForm;
    }
}
