using AutomationPracticeTests.WebDriver.Factory;
using OpenQA.Selenium;
using System;

namespace AutomationPracticeTests.CustomComponents
{
    public class Buttons
    {
        private string Name { get; set; }

        public Buttons(string buttonName)
        {
            Name = buttonName;
        }

        public IWebElement GetButtonByName() => DriverHelper
            .FindElement(By.XPath($"//div[contains(text(), '{Name}')] | //button[contains(text(), '{Name}')] | //a[contains(@href, '{Name}')] | //div[contains(@class, '{Name}')]"));

        public IWebElement GetButtonById() => DriverHelper
         .FindElement(By.Id(Name));

        public void Click() => GetButtonById().Click();
        
    }
}
