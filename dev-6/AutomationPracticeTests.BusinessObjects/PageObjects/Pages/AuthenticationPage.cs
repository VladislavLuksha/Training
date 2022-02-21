using AutomationPracticeTests.CustomComponents;
using AutomationPracticeTests.PageObjects.Pages;
using OpenQA.Selenium;

namespace AutomationPracticeTests.PageObjects.BasePages.Pages
{
    public class AuthenticationPage : BasePage
    {
        public AuthenticationPage() : base("Login - My Store") { }

        public Inputs InputCreateEmail => new Inputs("email_create");

        public Inputs InputEmail => new Inputs("email");

        public Inputs InputPassword => new Inputs("passwd");

        public Buttons ButtonCreateAnAccount => new Buttons("SubmitCreate");

        public Buttons ButtonSignIn => new Buttons("SubmitLogin");

        public BaseWebElement NotCorrectCreateEmail => new BaseWebElement(By.XPath("//div[@id='create_account_error']//li"));

        public AuthenticationPage FillEmail(string email)
        {
            InputCreateEmail.TypeText(email);

            return this;
        }

        public AuthenticationPage FillInLoginForm(string userName, string password)
        {
            InputEmail.TypeText(userName);
            InputPassword.TypeText(password);

            return this;
        }

        public AccountCreationPage ClickCreateAccountButton()
        {
            ButtonCreateAnAccount.Click();

            return new AccountCreationPage();
        }

        public MyAccountPage ClickSignInButton()
        {
            ButtonSignIn.Click();

            return new MyAccountPage();
        }
    }
}
