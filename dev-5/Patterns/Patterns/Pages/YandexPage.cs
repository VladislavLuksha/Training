using OpenQA.Selenium;
using Patterns.Exceptions;
using System;

namespace Patterns.Pages
{
    public class YandexPage : BasePage
    {
        private readonly By logInButton = By.XPath("//a[@class = 'home-link desk-notif-card__login-new-item desk-notif-card__login-new-item_enter home-link_black_yes home-link_hover_inherit']");
        private readonly By userNameInput = By.CssSelector(".username");
        private readonly By logOutButton = By.CssSelector("[aria-label = 'Выйти']");

        protected override string Url => "https://www.yandex.by";

        protected override string Title => "Яндекс";

        protected override string ExceptionMessage => "This no Yandex page!";

        public YandexPage(IWebDriver driver) : base(driver)
        {
            if (!IsLoaded())
            {
                throw new InvalidPageException(ExceptionMessage);
            }
        }

        public AuthorizationPage GoToAuthorizationPage()
        {
            var loginButton = WaitingForElement(logInButton);
            loginButton.Click();

            return new AuthorizationPage(Driver);
        }

        public void LogOutToYandexPage()
        {
            NavigateOnButton(userNameInput);
            NavigateOnButton(logOutButton);
        }

        public bool IsLogInAuthorizationPage()
        {
            var nameInput = Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(userNameInput));

            return !String.IsNullOrEmpty(nameInput.Text);
        }

        public bool IsLogOutAuthorizationPage()
        {
            var nameInput = WaitingForElement(logInButton);

            return !String.IsNullOrEmpty(nameInput.Text);
        }
    }
}
