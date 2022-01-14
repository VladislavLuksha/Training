using OpenQA.Selenium;
using Yandex.Utils;

namespace Yandex.Pages
{
    public class YandexPage : BasePage
    {
        private YandexLocators yandexLocators;
        public YandexPage(IWebDriver driver) : base(driver)
        {
            yandexLocators = new YandexLocators();
        }

        protected override string Url => "https://www.yandex.by";

        public void NavigateOnAuthorizationPage()
        {
            NavigateOnButton(yandexLocators.loginButton);
        }
    }
}
