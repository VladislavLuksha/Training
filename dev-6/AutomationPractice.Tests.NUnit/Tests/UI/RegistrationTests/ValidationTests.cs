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
    public class ValidationTests : BaseTest
    {
        private HomePage homePage => new HomePage();

        [Test]
        public void TestRegistration_RegistrationOfNewUserWithIncorrectEmail_UserGotWarningMessageUnderEmailField()
        {
            int stringLength = 4;
            string userEmail = RandomGeneratorHelper.GetRandomString(stringLength);
            string password = RandomGeneratorHelper.GetRandomString(stringLength);
            string errorMessageExpected = "Invalid email address.";

            User user = UserCreator.CreateUser(userEmail, password);

            // 1. Go to authentication page
            AuthenticationPage authenticationPage = homePage.OpenHomePage()
                .OpenAuthenticationPage();

            //Assert.IsNotNull(AuthenticationPage.GetTitle(), $"Title is present on {AuthenticationPage.GetTitle()}");

            // 2. Fill email address and click Create Account Button
            authenticationPage.FillEmail(user.Email)
                .ClickCreateAccountButton();

            string errorMessageActual = authenticationPage.GetIncorectData();

            Assert.AreEqual(errorMessageExpected, errorMessageActual, "Correct create email!");
        }

        [Test]
        public void TestRegistration_RegistrationOfNewUserWithPasswordLengthShorter_UserGotWarningMessageUnderPasswordField()
        {
            string errorMessageExpected = "passwd is invalid.";
            int stringLength = 3;
            User user = UserCreator.GetUser(UserType.ChromeUser);
            user.Email = RandomGeneratorHelper.GetRandomEmailString(stringLength);
            user.Password = RandomGeneratorHelper.GetRandomString(stringLength);

            // 1. Go to authentication page
            AuthenticationPage authenticationPage = homePage.OpenHomePage()
                .OpenAuthenticationPage();

            Assert.AreEqual(authenticationPage.TitlePage, authenticationPage.GetTitle(), $"{authenticationPage.TitlePage} not opened!");

            // 2. Fill Email address input and click Create an account button
            AccountCreationPage accountCreationPage = authenticationPage.FillEmail(user.Email)
                .ClickCreateAccountButton();

            Assert.AreEqual(accountCreationPage.TitlePage, accountCreationPage.GetTitleByLocator(), $"{accountCreationPage.TitlePage} not opened!");

            // 3. Fill all required fields
            accountCreationPage.FillRequiredFields(user);

            // 5. Click Register button
            accountCreationPage.ClickRegisterButton();

            string errorMessageActual = accountCreationPage.GetIncorectData();

            Assert.AreEqual(errorMessageExpected, errorMessageActual, "Password is correct(from 5 to 32 symbols) or password more than 32 symbols!");
        }

        [Test]
        public void TestRegistration_RegistrationOfNewUserWithPasswordLengthLonger_UserGotWarningMessageUnderPasswordField()
        {
            string errorMessageExpected = "passwd is too long. Maximum length: 32";
            int stringEmailLength = 4;
            int stringPasswordLength = 33;
            User user = UserCreator.GetUser(UserType.ChromeUser);
            user.Email = RandomGeneratorHelper.GetRandomEmailString(stringEmailLength);
            user.Password = RandomGeneratorHelper.GetRandomString(stringPasswordLength);

            // 1. Go to login page
            AuthenticationPage authenticationPage = homePage.OpenHomePage()
                .OpenAuthenticationPage();

            Assert.AreEqual(authenticationPage.TitlePage, authenticationPage.GetTitle(), $"{authenticationPage.TitlePage} not opened!");

            // 2. Fill Email address input and click Create an account button;
            AccountCreationPage accountCreationPage = authenticationPage.FillEmail(user.Email)
                .ClickCreateAccountButton();

            Assert.AreEqual(accountCreationPage.TitlePage, accountCreationPage.GetTitleByLocator(), $"{accountCreationPage.TitlePage} not opened!");

            // 3. Fill all required fields
            accountCreationPage.FillRequiredFields(user);

            // 5. Click Register button
            accountCreationPage.ClickRegisterButton();

            string errorMessageActual = accountCreationPage.GetIncorectData();

            Assert.AreEqual(errorMessageExpected, errorMessageActual, "Password is correct(from 5 to 32 symbols) or password less than 5 symbols!");
        }

        [Test]
        public void TestRegistration_RegistrationOfNewUserWithExistentEmail_UserGotWarningMessageUnderEmailField()
        {
            string errorMessageExpected = "An account using this email address has already been registered. Please enter a valid password or request a new one.";
            User user = UserCreator.GetUser(UserType.ChromeUser);

            // 1. Go to login page
            AuthenticationPage authenticationPage = homePage.OpenHomePage()
                .OpenAuthenticationPage();

            Assert.AreEqual(authenticationPage.TitlePage, authenticationPage.GetTitle(), $"{authenticationPage.TitlePage} not opened!");

            // 2.Fill Email address input and click Create an account button
            AccountCreationPage accountCreationPage = authenticationPage.FillEmail(user.Email)
                .ClickCreateAccountButton();

            string errorMessageActual = accountCreationPage.GetIncorectData();

            Assert.AreEqual(errorMessageExpected, errorMessageActual, "This user hasn't registered!");
        }
    }
}
