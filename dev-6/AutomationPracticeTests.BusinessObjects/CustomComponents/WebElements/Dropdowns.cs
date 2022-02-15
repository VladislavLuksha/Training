using AutomationPracticeTests.WebDriver.Factory;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

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
