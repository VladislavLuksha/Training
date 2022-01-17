using Yandex.Utils;
using OpenQA.Selenium;
using System;

namespace Yandex.Pages
{
    public class AuthorizationPage : BasePage
    {
        private AuthorizationLocators authorizationLocators;
            
        public AuthorizationPage(IWebDriver driver) : base(driver)
        {
            authorizationLocators = new AuthorizationLocators();
        }

        protected override string Url => "";

        public void LoginAuthorizationPage()
        {
            DataInput(authorizationLocators.userName, authorizationLocators.userNameInput);
            NavigateOnButton(authorizationLocators.loginButtonForAccount);
            DataInput(authorizationLocators.password, authorizationLocators.passwordInput);
        }

        public bool isLoginAuthorizationPage()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(authorizationLocators.messageStatusField));
            var messageStatus = Driver.FindElement(authorizationLocators.messageStatusField).Text;

            return String.IsNullOrEmpty(messageStatus);
        }
    }
}
