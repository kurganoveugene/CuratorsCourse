package form;

import aquality.selenium.forms.Form;
import org.openqa.selenium.By;

public class PersonalDetailsForm extends Form {

    public PersonalDetailsForm() {
        super(By.xpath("//h3[contains(text(),'Personal details')]"), "Personal details form");
    }
}
