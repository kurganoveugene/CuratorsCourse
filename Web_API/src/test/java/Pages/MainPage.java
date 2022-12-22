package Pages;

import aquality.selenium.forms.Form;
import forms.LeftUserMenuForm;
import org.openqa.selenium.By;

public class MainPage extends Form {
    LeftUserMenuForm leftUserMenuForm = new LeftUserMenuForm();

    public MainPage() {
        super(By.className("stories_feed_title"), "Main page");
    }

    public LeftUserMenuForm getLeftUserMenu() {
        return leftUserMenuForm;
    }
}
