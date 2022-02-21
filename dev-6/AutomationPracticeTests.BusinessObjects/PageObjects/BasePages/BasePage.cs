using AutomationPractice.Core.Extensions;
using AutomationPracticeTests.CustomComponents;
using AutomationPracticeTests.PageObjects.Pages;
using AutomationPracticeTests.WebDriver.Factory;
using OpenQA.Selenium;

namespace AutomationPracticeTests.PageObjects.BasePages
{
    public abstract class BasePage
    {
        protected BasePage(string title)
        {
            TitlePage = title;
        }

        protected BasePage(By titleLocator, string title)
        {
            TitlePage = title;
            TitleLocator = titleLocator;
        }

        public string TitlePage { get; set; }

        public TopNavigation TopNavigation => new TopNavigation();

        public BaseWebElement IncorrectData => new BaseWebElement(By.XPath("//div[@class='alert alert-danger']//li"));

        protected By TitleLocator { get; set; }

        public string GetIncorectData()
        {
            return IncorrectData.GetText();
        }

        public CartPage GoToCartPage()
        {
            TopNavigation.CartElement.Click();
            return new CartPage();
        }

        public string GetTitle() => Browser.Driver.Title;

        public string GetTitleByLocator() => DriverExtensions.FindElement(TitleLocator).Text;
    }
}
