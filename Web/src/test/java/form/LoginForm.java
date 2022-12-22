package form;
import aquality.selenium.elements.ElementType;
import aquality.selenium.elements.interfaces.*;
import aquality.selenium.forms.Form;
import org.openqa.selenium.By;
import utils.RandomUtil;

import java.util.List;

public class LoginForm extends Form {

    private final ITextBox textBoxPassword = getElementFactory().getTextBox(By.xpath("//input[contains(@placeholder,'Choose Password')]"), "Link start");
    private final ITextBox textBoxEmail = getElementFactory().getTextBox(By.xpath("//input[contains(@placeholder,'Your email')]"), "email");
    private final ITextBox textBoxDomain = getElementFactory().getTextBox(By.xpath("//input[contains(@placeholder,'Domain')]"), "domain text");
    private final IComboBox comboBoxDomain = getElementFactory().getComboBox(By.xpath("//div[contains(@class,'dropdown__field')]"), "Domain combo box");
    //private final ITextBox textBoxDomainListCheck = getElementFactory().getTextBox(By.xpath("//div [@class='dropdown__list-item']"), "Domain list check");
    private final ICheckBox checkBoxAccept = getElementFactory().getCheckBox(By.xpath("//span[contains(@class,'checkbox__box')]"), "check box accept");
    private final IButton buttonNext = getElementFactory().getButton(By.xpath("//a[contains(text(),'Next')]"), "Button next");

    public LoginForm() {
        super(By.xpath("//input[contains(@placeholder,'Choose Password')]"), "login Form");
    }

    public void setTextBoxPassword(String str) {
        textBoxPassword.clearAndType(str);
    }

    public void setTextBoxEmail(String str) {
        textBoxEmail.clearAndType(str);
    }

    public void setTextBoxDomain(String str) {
        textBoxDomain.clearAndType(str);
    }

    public void clickComboBoxDomain() {
        comboBoxDomain.click();
        List<ITextBox> textBoxesComboBox = getElementFactory().findElements(By.xpath("//div [@class='dropdown__list-item']"), ElementType.TEXTBOX);
        textBoxesComboBox.get(RandomUtil.getRandomInt(0,textBoxesComboBox.size())).click();
        }

    public void clickCheckBoxAccept() {
        checkBoxAccept.click();
    }

    public void clickButtonNext() {
        buttonNext.click();
    }
}
