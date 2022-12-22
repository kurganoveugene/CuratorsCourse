package seleniumWebdriver;
import aquality.selenium.core.utilities.ISettingsFile;
import aquality.selenium.core.utilities.JsonSettingsFile;
import java.awt.*;
import java.awt.datatransfer.StringSelection;
import java.awt.event.KeyEvent;
public class Utils {
 public static int[] randomCheckBox(int upperBound, int besidesTheNumber1, int besidesTheNumber2){
     int firstNumber = (int) (Math.random()*upperBound + 1);
     int secondNumber = (int) (Math.random()*upperBound + 1);
     int thirdNumber = (int) (Math.random()*upperBound + 1);
     int[] arrayOfRandomNumbers = new int[3];
     arrayOfRandomNumbers[0]= firstNumber;
     while ((firstNumber == secondNumber) || (firstNumber ==besidesTheNumber1) || (firstNumber ==besidesTheNumber2) || (secondNumber ==besidesTheNumber1) || (secondNumber ==besidesTheNumber2)){
         secondNumber = (int) (Math.random()*upperBound + 1);
     }
     arrayOfRandomNumbers[1] = secondNumber;
     while( (thirdNumber == secondNumber) && (thirdNumber == firstNumber)|| (thirdNumber ==besidesTheNumber1) || (thirdNumber ==besidesTheNumber2)){
         thirdNumber = (int) (Math.random()*upperBound + 1);
     }
     arrayOfRandomNumbers[2]= thirdNumber;
    return arrayOfRandomNumbers;
 }
 public static int oneRandomNumber(int upperBound){
     int number = (int) (Math.random()*upperBound+1);
     return number;
 }
     public static void downloadFile(String string){
         StringSelection stringSelection = new StringSelection(string);
         Toolkit.getDefaultToolkit().getSystemClipboard().setContents(stringSelection, null);
     Robot robot = null;
     try {
         robot = new Robot();
     } catch (AWTException e) {
         e.printStackTrace();
     }
     robot.delay(Integer.parseInt(getValueFromJson("/delayTime")));
     robot.keyPress(KeyEvent.VK_CONTROL);
     robot.keyPress(KeyEvent.VK_V);
     robot.keyRelease(KeyEvent.VK_V);
     robot.keyRelease(KeyEvent.VK_CONTROL);
     robot.keyPress(KeyEvent.VK_ENTER);
     robot.keyRelease(KeyEvent.VK_ENTER);
     }
     public static String getValueFromJson(String value){
         ISettingsFile testData = new JsonSettingsFile("testData.json");
         return testData.getValue(value).toString();
     }

}
