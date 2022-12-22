package page;
import aquality.selenium.elements.interfaces.ITextBox;
import aquality.selenium.forms.Form;
import form.*;
import org.openqa.selenium.By;

public class RegisterPage extends Form {
    private LoginForm loginForm=new LoginForm();
    private HelpForm helpForm= new HelpForm();
    private CookiesForm cookiesForm= new CookiesForm();
    private PersonalDetailsForm personalDetailsForm= new PersonalDetailsForm();
    private InterestsForm interestsForm= new InterestsForm();

    private final ITextBox timerText = getElementFactory().getTextBox(By.xpath("//div[contains(@class,'timer')]"), "Timer");

    public RegisterPage() {
        super(By.xpath("//button[contains(@class,'pagination__button')]"), "pagination button");
    }

    public LoginForm getLoginForm() {
        return loginForm;
    }

    public HelpForm getHelpForm() { return helpForm;}

    public CookiesForm getCookiesForm() {return cookiesForm;}

    public PersonalDetailsForm getPersonalDetailsForm() { return personalDetailsForm; }

    public InterestsForm getInterestsForm() { return interestsForm; }

    public String getTimerText() {
        return timerText.getText();
    }
}
