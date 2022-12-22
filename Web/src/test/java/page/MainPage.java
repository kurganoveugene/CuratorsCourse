package page;
import aquality.selenium.elements.interfaces.ILink;
import aquality.selenium.forms.Form;
import org.openqa.selenium.By;

public class MainPage extends Form {

    private final ILink linkStart = getElementFactory().getLink(By.xpath("//a[contains(@class,'start__link')]"), "Link start");

    public MainPage() {
        super(By.xpath("//button[contains(@class,'start__button')]"), "Main page");
    }
    public void linkStartClick() {
        linkStart.click();
    }
}
