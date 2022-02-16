using AutomationPracticeTests.WebDriver.Factory;
using OpenQA.Selenium;

namespace AutomationPracticeTests.CustomComponents
{
    public class Dropdowns
    {
        private string Name { get; set; }

        public Dropdowns(string dropdownName)
        {
            Name = dropdownName;
        }

        public IWebElement GetDropdownById() => DriverHelper
            .FindElement(By.Id(Name));
    }
}
