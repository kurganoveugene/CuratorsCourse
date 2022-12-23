using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class DropdownMenu : TextBox
    {
        public DropdownMenu(By locator, string name) : base(locator, name, ElementState.ExistsInAnyState)
        {
        }
    }
}
