package com.userinyerface.forms.gamepage;

import aquality.selenium.elements.interfaces.IButton;
import aquality.selenium.elements.interfaces.ICheckBox;
import aquality.selenium.elements.interfaces.ITextBox;
import aquality.selenium.forms.Form;
import com.userinyerface.utils.CheckBoxElementsManager;
import org.openqa.selenium.By;
import java.util.List;
import static aquality.selenium.elements.ElementType.CHECKBOX;

public class UpLoadFileForm extends Form {

    private final ICheckBox unselectAllCheckBox = getElementFactory().getCheckBox(By.xpath("//span[../span[text()='Unselect all']]"),
            "CheckBox 'Unselect all'");
    private final ITextBox divWrapperAvatarAndInterests = getElementFactory().getTextBox(By.xpath("//div[@class='avatar-and-interests']"),
            "Div Avatar and interests");
    private final IButton uploadFileBtn = getElementFactory().getButton(By.xpath("//a[@class='avatar-and-interests__upload-button']"),
            "Upload file button");

    public UpLoadFileForm() {
        super(By.xpath("//div[@class='avatar-and-interests__form']"), "UpLoadFile form");
    }

    public void unselectAllClick() {
        divWrapperAvatarAndInterests.getJsActions().scrollIntoView();
        unselectAllCheckBox.click();
    }

    public void selectInterestsElement(int count) {
        List<ICheckBox> checkBoxList = getElementFactory().
                findElements(By.xpath("//span[@class='checkbox small' and ./label[not(@for='interest_unselectall')]" +
                        " and ./label[not(@for='interest_selectall')]]"),CHECKBOX);
        CheckBoxElementsManager.selectElements(checkBoxList, count);
    }

    public void uploadFile(){
        uploadFileBtn.click();
    }
}
