package form;
import aquality.selenium.elements.interfaces.IButton;
import aquality.selenium.forms.Form;
import org.openqa.selenium.By;

public class CookiesForm extends Form {
    private final IButton buttonNo = getElementFactory().getButton(By.xpath("//button[contains(text(),'Not really, no')]"), "'Not really, no' button");

    public CookiesForm() {
        super(By.xpath("//p[contains(@class,'cookies__message')]"), "cookies form");
    }

    public void clickButtonNo() {
        buttonNo.click();
    }
}
