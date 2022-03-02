using OpenQA.Selenium;
using Patterns.Exceptions;

namespace Patterns.Pages
{
    public class AuthorizationPage : BasePage
    {
        private By userNameInput = By.Id("passp-field-login");
        private By passwordInput = By.Id("passp-field-passwd");
        private By sigInButton = By.Id("passp:sign-in");

        protected override string Title => "Авторизация";

        protected override string ExceptionMessage => "This no Authorization page!!!";

        public AuthorizationPage(IWebDriver driver) : base(driver)
        {
            if(!IsLoaded())
            {
                throw new InvalidPageException(ExceptionMessage);
            }
        }

        public void InputCredentials(string userName, string password)
        {
            DataInput(userName, userNameInput);
            WaitingForElement(sigInButton).Click();
            DataInput(password, passwordInput);
            WaitingForElement(sigInButton).Click();
        }
    }
}
