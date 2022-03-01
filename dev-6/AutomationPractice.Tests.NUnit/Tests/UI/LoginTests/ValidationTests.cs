using Allure.Commons;
using AutomationPracticeTests.BaseTests;
using AutomationPracticeTests.Entities;
using AutomationPracticeTests.PageObjects.BasePages.Pages;
using AutomationPracticeTests.PageObjects.Pages;
using AutomationPracticeTests.Utilities.Enums;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace AutomationPracticeTests.Tests.UI.LoginTests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("LoginTests")]
    [AllureSubSuite("ValidationTests")]
    public class ValidationTests : BaseTest
    {
        [Test(Description = "Login with invalid credentials")]
        [AllureIssue("ISSUE-2")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Vladislav")]
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
