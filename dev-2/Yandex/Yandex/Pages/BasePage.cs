using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Yandex.Pages
{
    abstract public class BasePage
    {
        private const int WAIT_FOR_ELEMENT_TIMEOUT = 20;

        protected IWebDriver Driver { get; set; }

        protected WebDriverWait Wait { get; set; }

        protected abstract string Url { get; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT_TIMEOUT));
            Driver.Manage().Window.Maximize();
        }

        public void GoTo()
        {
            Driver.Navigate().GoToUrl(Url);
        }

        public void NavigateOnButton(By locator)
        {
            Wait.Until(t => Driver.FindElement(locator).Displayed);
            Driver.FindElement(locator).Click();
        }

        public void DataInput(string text, By locator)
        {
            var element = Driver.FindElement(locator);
            element.SendKeys(text + Keys.Enter);
        }
    }
}
