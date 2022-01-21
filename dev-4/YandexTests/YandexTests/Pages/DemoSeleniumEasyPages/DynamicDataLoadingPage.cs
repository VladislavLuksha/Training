using OpenQA.Selenium;
using System;

namespace YandexTests.Pages
{
    public class DynamicDataLoadingPage : BasePage
    {
        public readonly By getNewUser = By.Id("save");
        private readonly By userImg = By.XPath("//div[@id ='loading']");

        public DynamicDataLoadingPage(IWebDriver driver) : base(driver)
        {

        }

        protected override string Url => "https://demo.seleniumeasy.com/dynamic-data-loading-demo.html";

        public bool isUserWaited()
        {
            var element = WaitingForElement(userImg);

            return !String.IsNullOrEmpty(element.Text);
        }
    }
}
