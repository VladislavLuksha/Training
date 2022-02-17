using AutomationPractice.Core.Extensions;
using OpenQA.Selenium;

namespace AutomationPracticeTests.CustomComponents
{
    public class Buttons
    {
        private string Name { get; set; }

        public Buttons(string buttonName)
        {
            Name = buttonName;
        }

        public IWebElement GetButtonByName() => DriverExtensions
            .FindElement(By.XPath($"//div[contains(text(), '{Name}')] | //button[contains(text(), '{Name}')] | //a[contains(@href, '{Name}')] | //div[contains(@class, '{Name}')]"));

        public IWebElement GetButtonById() => DriverExtensions
         .FindElement(By.Id(Name));

        public void Click() => GetButtonById().Click();
    }
}
