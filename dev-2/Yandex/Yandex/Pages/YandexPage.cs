using OpenQA.Selenium;

namespace Yandex.Pages
{
    public class YandexPage : BasePage
    {
        private readonly By loginButton = By.XPath("//a[contains(@class, 'item_enter')]");

        public YandexPage(IWebDriver driver) : base(driver) { }
       
        protected override string Url => "https://www.yandex.by";

        public void NavigateOnAuthorizationPage()
        {
            NavigateOnButton(loginButton);
        }
    }
}
