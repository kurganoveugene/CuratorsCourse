using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TestProject1
{
    public class PersonalDetailsForm : Form
    {
        public PersonalDetailsForm() : base(By.XPath("//div[@class='personal-details__tr-row']//*[text()[contains(.,'Zip')]]"), "Personal Details Form")
        {
        }
    }
}
