using AutomationPracticeTests.CustomComponents;
using AutomationPracticeTests.PageObjects.Pages;
using OpenQA.Selenium;

namespace AutomationPracticeTests.PageObjects.BasePages
{
    public abstract class BasePage
    {
        protected BasePage()
        {
            //TitlePage = title;
        }

        public static string TitlePage { get; set; }

        public TopNavigation TopNavigation => new TopNavigation();

        public BaseWebElement IncorrectData => new BaseWebElement(By.XPath("//div[@class='alert alert-danger']//li"));

        public string GetIncorectData()
        {
            return IncorrectData.GetText();
        }

        public CartPage GoToCartPage()
        {
            TopNavigation.CartElement.Click();

            return new CartPage();
        }

        //public string GetTitle() => DriverHelper.;
    }
}
