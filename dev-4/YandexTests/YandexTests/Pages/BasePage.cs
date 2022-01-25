using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace YandexTests.Pages
{
    public abstract class BasePage
    {
        private const int WAIT_FOR_ELEMENT_TIMEOUT = 20;

        protected IWebDriver Driver { get; set; }
        
        protected WebDriverWait Wait { get; set; }

        protected virtual string Url { get; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(WAIT_FOR_ELEMENT_TIMEOUT);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT_TIMEOUT));
        }

        public void GoTo()
        {
            Driver.Navigate().GoToUrl(Url);
        }

        public void DataInput(string text, By locator)
        {
            var element = WaitingForElement(locator);
            element.SendKeys(text + Keys.Enter);
        }

        public IWebElement WaitingForElement(By locator)
        {
            return Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public void NavigateOnButton(By locator)
        {
            WaitingForElement(locator).Click();
        }
    }
}
