using OpenQA.Selenium;
using System;

namespace YandexTests.Pages
{
    public class DynamicDataLoadingPage : BasePage
    {
        private readonly By getNewUserButton = By.Id("save");
        private readonly By userImg = By.XPath("//div[@id ='loading']");

        protected override string Url => "https://demo.seleniumeasy.com/dynamic-data-loading-demo.html";

        public DynamicDataLoadingPage(IWebDriver driver) : base(driver)
        {

        }

        public bool IsUserWaited()
        {
            var element = WaitingForElement(userImg);

            return !String.IsNullOrEmpty(element.Text);
        }

        public void ClickOnGetNewUserButton()
        {
            NavigateOnButton(getNewUserButton);
        }
    }
}
