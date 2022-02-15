using AutomationPracticeTests.BaseTests;
using AutomationPracticeTests.Entities;
using AutomationPracticeTests.PageObjects.BasePages.Pages;
using AutomationPracticeTests.PageObjects.Pages;
using AutomationPracticeTests.Utilities.Enums;
using NUnit.Framework;

namespace AutomationPracticeTests
{
    [TestFixture]
    public class SmokeTests : BaseTest
    {
        [Test]
        public void TestLogin_LoginWithValidCredentials_UserSuccesfullyLoggedIn()
        {
            bool isLoggedInExpected = true;
            User user = UserCreator.GetUser(UserType.ChromeUser);
            HomePage homePage = new HomePage();

            // 1. Go to authentication page
            AuthenticationPage authenticationPage = homePage.OpenHomePage()
                .OpenAuthenticationPage();

            // 2. Login
            MyAccountPage myAccountPage = authenticationPage.FillInLoginForm(user.Email, user.Password)
                .ClickSignInButton();
          
            bool isLoggedInActual = myAccountPage.IsLoggedMyAccountPage();

            // 1. Verify the ability to login in account
            Assert.AreEqual(isLoggedInExpected, isLoggedInActual, "Login failed!");
        }
    }
}