package form;
import aquality.selenium.elements.interfaces.IButton;
import aquality.selenium.forms.Form;
import org.openqa.selenium.By;

public class HelpForm extends Form {

    private final IButton buttonSend = getElementFactory().getButton(By.xpath("//button[contains(@class,'help-form__send-to-bottom-button')]"), "send to button");

    public HelpForm() {
        super(By.xpath("//h2[contains(@class,'help-form__title')]"), "Help form");
    }

    public void clickButtonSend() {
        buttonSend.click();
    }
}
