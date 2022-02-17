using AutomationPractice.Core.Extensions;
using OpenQA.Selenium;

namespace AutomationPracticeTests.CustomComponents
{
    public class Inputs
    {
        private string Name { get; set; }

        public Inputs(string inputName)
        {
            Name = inputName;
        }

        public IWebElement GetInputByName() => DriverExtensions
            .FindElement(By.XPath($"//input[contains(@placeholder, '{Name}')] | //input[contains(@class, '{Name}')] | //input[contains(@value, '{Name}')] | //input[contains(@type, '{Name}')] | //input[contains(@id, '{Name}')]"));

        public IWebElement GetInputById() => DriverExtensions
           .FindElement(By.Id(Name));

        public void TypeText(string textInput) => GetInputById().SendKeys(textInput);
    }
}
