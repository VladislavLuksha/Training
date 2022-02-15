using AutomationPracticeTests.WebDriver.Factory;
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
            Element = DriverHelper.FindSelectElement(By.Id(Name));
        }

        public void SelectElementByText(string elementName)
        {
            try
            {
                SelectElement.SelectByText(elementName);
            }
            catch(NoSuchElementException e)
            {

            }
        }
    }
}
