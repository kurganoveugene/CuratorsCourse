package Pages;


import aquality.selenium.forms.Form;
import forms.LoginForm;
import org.openqa.selenium.By;

public class LoginPage extends Form {
    LoginForm loginForm = new LoginForm();

    public LoginPage() {
        super(By.className("IndexPageContent__content"), "Main page");
    }

    public LoginForm getLoginForm() {
        return loginForm;
    }
}
