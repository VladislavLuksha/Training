using AutomationPracticeTests.BaseTests;
using AutomationPracticeTests.Entities;
using AutomationPracticeTests.PageObjects.BasePages.Pages;
using AutomationPracticeTests.PageObjects.Pages;
using AutomationPracticeTests.Utilities.Enums;
using NUnit.Framework;

namespace AutomationPracticeTests.Tests.LoginTest
{
    [TestFixture]
    public class ValidationTests : BaseTest
    {
        [Test]
        public void TestLogin_LoginWithInvalidCredentials_UserGotWarningMessagePasswordField()
        {
            string errorMessageExpected = "Authentication failed.";
            User user = UserCreator.GetUser(UserType.NotCorrectUser);
            HomePage homePage = new HomePage();

            // 1. Go to authentication page
            AuthenticationPage authenticationPage = homePage.OpenHomePage()
                .OpenAuthenticationPage();

            Assert.AreEqual(authenticationPage.TitlePage, authenticationPage.GetTitle(), $"{authenticationPage.TitlePage} not opened!");

            // 2. Login
            authenticationPage.FillInLoginForm(user.Email, user.Password)
                .ClickSignInButton();

            string errorMessageActual = authenticationPage.GetIncorectData();

            Assert.AreEqual(errorMessageExpected, errorMessageActual, "Correct paswword!");
        }
    }
}
