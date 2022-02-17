using AutomationPracticeTests.BaseTests;
using AutomationPracticeTests.Entities;
using AutomationPracticeTests.PageObjects.BasePages.Pages;
using AutomationPracticeTests.PageObjects.Pages;
using AutomationPracticeTests.Utilities;
using AutomationPracticeTests.Utilities.Enums;
using NUnit.Framework;

namespace AutomationPracticeTests.Tests.UI.RegistrationTests
{
    [TestFixture]
    public class SmokeTests : BaseTest
    {
        [Test]
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

            // 2. Fill Email address input and click Create an account button
            AccountCreationPage accountCreationPage = authenticationPage.FillEmail(user.Email)
                .ClickCreateAccountButton();

            // 4. Fill all required fields
            accountCreationPage.FillRequiredFields(user);

            // 5. Click Register button
            MyAccountPage myAccountPage = accountCreationPage.ClickRegisterButton();

            bool isRegistratedAccountActual = myAccountPage.IsLoggedMyAccountPage();

            // 1. Verify the ability to create an account
            Assert.AreEqual(isRegistratedAccountExpected, isRegistratedAccountActual, "User account not registered!");
        }
    }
}
