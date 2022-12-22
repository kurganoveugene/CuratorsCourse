package seleniumWebdriver;
import aquality.selenium.browser.Browser;
import aquality.selenium.elements.ElementType;
import aquality.selenium.elements.interfaces.*;
import org.openqa.selenium.By;
import java.util.ArrayList;
import java.util.List;
import static aquality.selenium.browser.AqualityServices.getBrowser;
public class UserinyerfaceForm extends Form{
    private final IButton clickHereButton = getElementFactory().getButton(By.className("start__link"), "Button 'Here'");
    private final IButton nextButton = getElementFactory().getButton(By.xpath("//*[contains(text(),'Next')]"), "Button to the next page");
    public UserinyerfaceForm() {
        super(By.className("logo__icon"), "Welcome Page Element");
    }
    public void clickHereToGoToTHeNextPage(){
        clickHereButton.clickAndWait();
    }
    public class FirstAuthorizationForm extends Form{
        private final ITextBox txbEmail = getElementFactory().getTextBox(By.xpath("//input[@placeholder='Your email']"), "Email textBox");
        private final ITextBox txbDomain = getElementFactory().getTextBox(By.xpath("//input[@placeholder='Domain']"), "Domain textBox");
        private final ITextBox txbPassword = getElementFactory().getTextBox(By.xpath("//input[@placeholder='Choose Password']"), "Password textBox");
        private final IComboBox dropdownOpener = getElementFactory().getComboBox(By.className("dropdown__opener"), "Dropdown opener");
        private final ICheckBox checkBoxOfAcceptingTheTermsOfUse = getElementFactory().getCheckBox(By.xpath("//span[contains(@class,'icon-check')]"),"Accepting the terms of use");
        private final IComboBox dropdownList = getElementFactory().getComboBox(By.xpath("//div[@class='dropdown__list']"), "Dropdown List");
        private String partOfEmail;
       public FirstAuthorizationForm() {
           super(By.xpath("//div[contains(text(),'1 / 4')]"), "First Authorization Page");
       }
        public void acceptingTheTermsOfUse(){
            checkBoxOfAcceptingTheTermsOfUse.check();
        }
        public void inputEmail(){
            PasswordGenerator passwordGenerator1 = new PasswordGenerator.PasswordGeneratorBuilder()
                    .useDigits(true)
                    .useLower(true)
                    .useUpper(true)
                    .usePunctuation(false)
                    .build();
            txbEmail.clearAndTypeSecret(passwordGenerator1.generate(10));
            partOfEmail = passwordGenerator1.generate(10).substring(7);
        }
        public void inputPassword(){
            PasswordGenerator passwordGenerator = new PasswordGenerator.PasswordGeneratorBuilder()
                    .useDigits(true)
                    .useLower(true)
                    .useUpper(true)
                    .usePunctuation(true)
                    .build();
            txbPassword.clearAndTypeSecret(passwordGenerator.generate(10)+partOfEmail);
        }
        public void inputDomain(){
            PasswordGenerator passwordGenerator = new PasswordGenerator.PasswordGeneratorBuilder()
                    .useDigits(true)
                    .useLower(true)
                    .useUpper(true)
                    .usePunctuation(true)
                    .build();
            txbDomain.clearAndTypeSecret(passwordGenerator.generate(4));
        }
        public void clickDropdownOpener(){
            dropdownOpener.click();
            final IButton selectItem = getElementFactory().getButton(By.xpath("(//div[contains(@class,'dropdown__list-item')])["+Utils.oneRandomNumber(dropdownList.findChildElements(By.xpath("//div[contains(@class,'dropdown__list-item')]"), ElementType.BUTTON).size())+"]"), "Select item");
            selectItem.click();
        }
        public void clickNextButton(){
            nextButton.clickAndWait();
        }
    }
    public class SecondAuthorizationForm extends Form{
        private final ICheckBox unselectAllCheckbox = getElementFactory().getCheckBox(By.xpath("//label[contains(@for,'unselectall')]"), "CheckBox 'Unselect all'");
        private final ITextBox checkBoxMenu = getElementFactory().getTextBox(By.className("avatar-and-interests__interests-list"), "CheckBox menu");
        private final IButton buttonDownloadImage = getElementFactory().getButton(By.xpath("//a[contains(text(),'upload')]"), "Button 'upload'");
        private final IComboBox allCheckBoxes = getElementFactory().getComboBox(By.xpath("//div[@class='avatar-and-interests__interests-list']"), "All checkBoxes");
        public SecondAuthorizationForm() {
            super(By.xpath("//div[contains(text(),'2 / 4')]"), "Second Authorization Page");
        }
        public void selectedThreeCheckBoxes(){
            unselectAllCheckbox.check();
            List<String> attributesOfCheckBoxes = new ArrayList<>();
            for(int i = 1;i<= allCheckBoxes.findChildElements(By.className("avatar-and-interests__interests-list__item"), ElementType.CHECKBOX).size(); i++){
                ICheckBox checkBox1 = getElementFactory().getCheckBox(By.xpath("(//label[@class='checkbox__label'])["+i+"]"), "Download");
                attributesOfCheckBoxes.add(checkBox1.getAttribute("for"));
            }
            int indexOfSelectAllCheckBox= attributesOfCheckBoxes.indexOf("interest_selectall") +1;
            int indexOfUnselectAllCheckBox = attributesOfCheckBoxes.indexOf("interest_unselectall")+1;
            int[] arrayOfNumbersOfRandomCheckBoxes =  Utils.randomCheckBox(checkBoxMenu.findChildElements(By.xpath("//div[@class='avatar-and-interests__interests-list__item']"), ElementType.CHECKBOX).size(), indexOfSelectAllCheckBox,indexOfUnselectAllCheckBox);
            for(int i=0; i<arrayOfNumbersOfRandomCheckBoxes.length;i++){
                ICheckBox selectedCheckBox = getElementFactory().getCheckBox(By.xpath("(//span[@class='checkbox small'])["+arrayOfNumbersOfRandomCheckBoxes[i]+"]"), "Selected checkBox");
                selectedCheckBox.check();
            }
        }
        public void downloadImage() {
            buttonDownloadImage.click();
            Utils.downloadFile(System.getProperty("user.dir")+Utils.getValueFromJson("/wayToFile")+Utils.getValueFromJson("/fileName"));
        }
        public void doubleClickNextButton(){
            nextButton.getMouseActions().doubleClick();
        }
    }
    public class ThirdAuthorizationForm extends Form{
        public ThirdAuthorizationForm(){
            super(By.xpath("//div[contains(text(),'3 / 4')]"), "Third Authorization Page");
        }
    }
    public class HelpForm extends Form{
        private final IComboBox helpForm = getElementFactory().getComboBox(By.className("help-form"), "Help form");
        private final IButton buttonSkipHelp = getElementFactory().getButton(By.xpath("//button[contains(@class,'help-form__send')]"), "Skip help window");
        public HelpForm(){
            super(By.className("help-form__container"), "Help window");
        }
        public void skipHelpWindow(){
            buttonSkipHelp.clickAndWait();
        }
        public String attributeFromHelpForm(){
            return helpForm.getAttribute("class");
        }
    }
     public class CookiesForm extends Form{
        private final IButton acceptCookies = getElementFactory().getButton(By.xpath("//button[contains(@class,'transparent')]"),"Accepting Cookies Button");
        public CookiesForm() {
        super(By.xpath("//div[@class='cookies']"), "Cookies");
    }
        public void acceptTheUseOfCookies(){
        acceptCookies.clickAndWait();
    }
    }
    public class TimerForm extends Form{
        private final ILabel timerLabel = getElementFactory().getLabel(By.xpath("//div[contains(@class,'timer')]"), "Timer");
        Browser browserTabNavigation = getBrowser();
        public TimerForm(){
            super(By.xpath("//div[contains(@class,'timer')]"), "Timer");
        }
           public String getTimerTime(){
              return timerLabel.getText();
           }
        public void refreshPage(){
            browserTabNavigation.refresh();
        }
    }
}
