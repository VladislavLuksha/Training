using AutomationPractice.Core.Extensions;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace AutomationPracticeTests.CustomComponents.WebElements
{
    public class Table
    {
        private string Name { get; set; }

        public Table(string name)
        {
            Name = name;
        }

        public IList<IWebElement> GetInputByXPath() => DriverExtensions
           .FindElements(By.XPath($"//div[@class = '{Name}']"));
    }
}
