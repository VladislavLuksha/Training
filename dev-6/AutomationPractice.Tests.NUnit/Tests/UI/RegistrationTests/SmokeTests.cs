using Allure.Commons;
using AutomationPracticeTests.BaseTests;
using AutomationPracticeTests.Entities;
using AutomationPracticeTests.PageObjects.BasePages.Pages;
using AutomationPracticeTests.PageObjects.Pages;
using AutomationPracticeTests.Utilities;
using AutomationPracticeTests.Utilities.Enums;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace AutomationPracticeTests.Tests.UI.RegistrationTests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("RegistrationTests")]
    [AllureSubSuite("SmokeTests")]
    [AllureDisplayIgnored]
    public class SmokeTests : BaseTest
    {
        [Test(Description = "Registration of new user with valid credentials")]
        [AllureIssue("ISSUE-3")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Vladislav")]
        public void TestRegistration_RegistrationOfNewUser_UserSuccessfullyRegistered()
        {
            bool isRegistratedAccountExpected = true;
            int stringLength = 7;
            User user = UserCreator.GetUser(UserType.ChromeUser);
            user.Email = RandomGeneratorHelper.GetRandomEmailString(stringLength);
            user.Password = RandomGeneratorHelper.GetRandomString(stringLength);
            HomePage homePage = new HomePage();

            // 1. Go to authentication page
            AuthenticationPage authenticationPage = homePage.OpenHomePage()
                .OpenAuthenticationPage();

            Assert.AreEqual(authenticationPage.TitlePage, authenticationPage.GetTitle(), $"{authenticationPage.TitlePage} not opened!");

            // 2. Fill Email address input and click Create an account button
            AccountCreationPage accountCreationPage = authenticationPage.FillEmail(user.Email)
                .ClickCreateAccountButton();

            Assert.AreEqual(accountCreationPage.TitlePage, accountCreationPage.GetTitleByLocator(), $"{accountCreationPage.TitlePage} not opened!");

            // 4. Fill all required fields
            accountCreationPage.FillRequiredFields(user);

            // 5. Click Register button
            MyAccountPage myAccountPage = accountCreationPage.ClickRegisterButton();

            Assert.AreEqual(myAccountPage.TitlePage, myAccountPage.GetTitle(), $"{myAccountPage.TitlePage} not opened!");

            bool isRegistratedAccountActual = myAccountPage.IsLoggedMyAccountPage();

            // 1. Verify the ability to create an account
            Assert.AreEqual(isRegistratedAccountExpected, isRegistratedAccountActual, "User account not registered!");
        }
    }
}
