package forms;

import aquality.selenium.elements.interfaces.IButton;
import aquality.selenium.forms.Form;
import org.openqa.selenium.By;

public class LeftUserMenuForm extends Form {
    private final IButton buttonMyPage = getElementFactory().getButton(By.className("inl_bl"), "button My Page");

    public LeftUserMenuForm() {
        super(By.className("side_bar_nav"), "Login form");
    }

    public void clickButtonMyPage() {
        buttonMyPage.click();
    }
}
