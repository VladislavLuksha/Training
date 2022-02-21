using Allure.Commons;
using AutomationPracticeTests.BaseTests;
using AutomationPracticeTests.Entities;
using AutomationPracticeTests.PageObjects.BasePages.Pages;
using AutomationPracticeTests.PageObjects.Pages;
using AutomationPracticeTests.Utilities.Enums;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace AutomationPracticeTests
{
    [TestFixture("ChromeWindows")]
    [TestFixture("FirefoxWindows")]
    [AllureNUnit]
    [AllureDisplayIgnored]
    //[Parallelizable]
    public class SmokeTests : BaseTest
    {
        public SmokeTests(string environment) : base(environment)
        { 
        }

        [Test(Description = "Login with valid credentials")]
        [AllureIssue("ISSUE-1")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Vladislav")]
        public void TestLogin_LoginWithValidCredentials_UserSuccesfullyLoggedIn()
        {
            bool isLoggedInExpected = true;
            User user = UserCreator.GetUser(UserType.ChromeUser);
            HomePage homePage = new HomePage();

            // 1. Go to authentication page
            AuthenticationPage authenticationPage = homePage.OpenHomePage()
                .OpenAuthenticationPage();

            Assert.AreEqual(authenticationPage.TitlePage, authenticationPage.GetTitle(), $"{authenticationPage.TitlePage} not opened!");
            
            // 2. Login
            MyAccountPage myAccountPage = authenticationPage.FillInLoginForm(user.Email, user.Password)
                .ClickSignInButton();

            Assert.AreEqual(myAccountPage.TitlePage, myAccountPage.GetTitle(), $"{myAccountPage.TitlePage} not opened!");

            bool isLoggedInActual = myAccountPage.IsLoggedMyAccountPage();

            // 1. Verify the ability to login in account
            Assert.AreEqual(isLoggedInExpected, isLoggedInActual, "Login failed!");
        }
    }
}