package forms;

import aquality.selenium.elements.interfaces.IButton;
import aquality.selenium.elements.interfaces.ITextBox;
import aquality.selenium.forms.Form;
import org.openqa.selenium.By;

public class LoginForm extends Form {

    private final ITextBox textBoxEmail = getElementFactory().getTextBox(By.name("email"), "email or phone input");
    private final ITextBox textBoxPassword = getElementFactory().getTextBox(By.name("pass"), "Password input");
    private final IButton buttonEnter = getElementFactory().getButton(By.id("index_login_button"), "Button enter");

    public LoginForm() {
        super(By.id("index_login"), "Login form");
    }

    public void setTextBoxEmail(String email) {
        textBoxEmail.clearAndType(email);
    }

    public void setTextBoxPassword(String password) {
        textBoxPassword.clearAndType(password);
    }

    public void clickButtonEnter() {
        buttonEnter.click();
    }
}
