using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Patterns.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver { get; set; } 

        protected WebDriverWait Wait { get; set; }

        private const int WAIT_FOR_ELEMENT_TIMEOUT = 20;

        protected virtual string Url { get; }

        protected virtual string Title { get; }

        protected virtual string ExceptionMessage { get; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT_TIMEOUT));
        }

        public void GoTo()
        {
            Driver.Navigate().GoToUrl(Url);
        }

        public bool IsLoaded()
        {
            return getPageTitle().Equals(Title);
        }

        public string getPageTitle()
        {
            return Driver.Title;
        }

        public void DataInput(string text, By locator)
        {
            var element = WaitingForElement(locator);
            element.SendKeys(text);
        }

        public IWebElement WaitingForElement(By locator)
        {
            return Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
        }

        public void NavigateOnButton(By locator)
        {
            var button = WaitingForElement(locator);
            button.Click();
        }
    }
}
