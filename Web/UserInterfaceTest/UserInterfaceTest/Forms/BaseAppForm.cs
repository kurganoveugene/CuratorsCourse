using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace UserInterfaceTest.Forms
{
    public class BaseAppForm : Form
    {
        protected BaseAppForm(By locator, string name) : base(locator, name) 
        {
        
        }
    }
}
