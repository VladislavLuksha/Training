using AutomationPractice.Core.Extensions;
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

        public IWebElement GetDropdownById() => DriverExtensions
            .FindElement(By.Id(Name));
    }
}
