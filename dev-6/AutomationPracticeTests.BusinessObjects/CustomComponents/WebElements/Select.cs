using AutomationPractice.Core.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationPracticeTests.CustomComponents
{
    public class Select
    {
        private IWebElement Element { get; set; }

        private SelectElement SelectElement => new SelectElement(Element);

        private string Name { get; set; }

        public Select(string name)
        {
            Name = name;
            Element = DriverExtensions.FindSelectElement(By.Id(Name));
        }

        public void SelectElementByText(string elementName)
        {
            SelectElement.SelectByText(elementName);
        }
    }
}
