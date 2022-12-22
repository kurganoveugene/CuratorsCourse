package form;

import aquality.selenium.elements.ElementType;
import aquality.selenium.elements.interfaces.IButton;
import aquality.selenium.elements.interfaces.ICheckBox;
import aquality.selenium.forms.Form;
import org.openqa.selenium.By;
import utils.RandomUtil;

import java.util.List;

public class InterestsForm extends Form {

    private final IButton buttonNext = getElementFactory().getButton(By.xpath("//button[contains(text(),'Next')]"), "Button next interests form");
    private final IButton buttonUpload = getElementFactory().getButton(By.xpath("//a[contains(@class,'avatar-and-interests__upload-button')]"), "Button upload interests form");
    private final ICheckBox checkBoxeUnSelectAll = getElementFactory().getCheckBox(By.xpath("//label[contains(@class,'checkbox__label')and contains(@for,'interest_unselectall')]"), "check box Unselect all");

    public InterestsForm() {
        super(By.xpath("//h2[contains(@class,'avatar-and-interests__title')]"), "interests form");
    }

    public void clickButtonNext() {
        buttonNext.click();
    }

    public void clickButtonUpload() {
        buttonUpload.click();
    }

    public void randomCheckBoxInterest() {
        checkBoxeUnSelectAll.click();
        List<ICheckBox> checkBoxes = getElementFactory().findElements(By.xpath("//label[contains(@class,'checkbox__label')  and not(contains(@for,'selectall'))]"), ElementType.CHECKBOX);
        int rand, i = 0;
        while (i < 3) {
            rand = RandomUtil.getRandomInt(0, checkBoxes.size());
            if (!checkBoxes.get(rand).isChecked()) {
                checkBoxes.get(rand).check();
                i++;
            }
        }
    }
}
