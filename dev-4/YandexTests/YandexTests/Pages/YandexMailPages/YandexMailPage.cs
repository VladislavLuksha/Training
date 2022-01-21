using OpenQA.Selenium;

namespace YandexTests.Pages
{
    public class YandexMailPage : BasePage
    {
        private readonly By logInButton = By.CssSelector(".button2_theme_mail-white");
        public YandexMailPage(IWebDriver driver) : base(driver)
        {
            Driver.Manage().Window.Maximize();
        }

        protected override string Url => "https://mail.yandex.com/";
        public AuthorizationPage LogInAuthorizationPage()
        {
            var element = Driver.FindElement(logInButton);
            element.Click();
            return new AuthorizationPage(Driver);
        }
    }
}
