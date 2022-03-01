using OpenQA.Selenium;
using System;

namespace Yandex.Pages
{
    public class AuthorizationPage : BasePage
    {
        private readonly By userNameInput = By.Id("passp-field-login");
        private readonly By loginForAccountButton = By.Id("passp:sign-in");
        private readonly By passwordInput = By.Id("passp-field-passwd");
        private readonly By messageStatusField = By.XPath("//span[@class='username__first-letter']");
      
        public AuthorizationPage(IWebDriver driver) : base(driver) { }
      
        protected override string Url => "";

        public void LoginAuthorizationPage(string userName, string password)
        {
            DataInput(userName, userNameInput);
            NavigateOnButton(loginForAccountButton);
            DataInput(password, passwordInput);
            NavigateOnButton(loginForAccountButton);
        }

        public bool isLoginAuthorizationPage()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(messageStatusField));
            var messageStatus = Driver.FindElement(messageStatusField).Text;

            return !String.IsNullOrEmpty(messageStatus);
        }
    }
}
