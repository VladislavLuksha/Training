using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace YandexTests.Pages
{
    public class AuthorizationPage : BasePage
    {
        private readonly By userNameInput = By.Id("passp-field-login");
        private readonly By passwordInput = By.CssSelector("#passp-field-passwd");
        private readonly By userAccountLink = By.CssSelector(".user-account_left-name");

        public AuthorizationPage(IWebDriver driver) : base(driver)
        {

        }

        public void LoginAuthorizationPage(string userName, string password)
        {
            DataInput(userName, userNameInput);
            DataInput(password, passwordInput);
        }

        public bool WaitForAfterLoginPage()
        {
            var element = Wait.Until(t =>
            {
                try
                {
                    return Driver.FindElement(userAccountLink).Displayed;
                }
                catch(StaleElementReferenceException)
                {
                    return false;
                }
                catch(NoSuchElementException)
                {
                    return false;
                }
            });

            return element;
        }
    }
}
