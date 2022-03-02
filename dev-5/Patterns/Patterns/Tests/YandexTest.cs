using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using Patterns.Helpers;
using Patterns.Pages;
using Patterns.Providers;
using Patterns.Tests;
using Patterns.Utils;

namespace Patterns
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("YandexTests")]
    [AllureDisplayIgnored]
    public class YandexTest : BaseTest
    {
        private YandexPage yandexPage;
        private CredentialsConstants credentialsConstants;
     
        [SetUp]
        public void Setup()
        {
            Driver.Navigate().GoToUrl("https://www.yandex.by");
            yandexPage = new YandexPage(Driver);
            InitializeCredentials();
        }

        [Test(Description = "The test verifies that the Authorization page is logged in")]
        [AllureTag("CI")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureOwner("Vladislav")]
        [AllureSubSuite("GoTo")]
        [AllureStep("Checks that Authorization Page is logged in: {loginStatusExpected}, {loginStatusActual}")]
        public void GoToAuthorizationPageTest()
        {
            bool loginStatusExpected = true;

            ScreenshotTakerHelper.TakeScreenshot(ScreenshotsDirectory, "YandexPage");

            // 1. Login to Authorization Page
            AuthorizationPage authorizationPage = yandexPage.GoToAuthorizationPage();
      
            // 2. Input username and password on Authorization Page
            authorizationPage.InputCredentials(credentialsConstants.UserName, credentialsConstants.Password);

            bool loginStatusActual = yandexPage.IsLogInAuthorizationPage();

            // 1. Verify that the Authorization page is logged in 
            Assert.AreEqual(loginStatusExpected, loginStatusActual, "The Authorization page isn't logged in!!!");
        }

        [Test(Description = "The test verifies that the Authorization page is logged out")]
        [AllureTag("CI")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-2")]
        [AllureTms("TMS-5")]
        [AllureOwner("Vladislav")]
        [AllureSubSuite("LogOut")]
        public void LogOutToAuthorizationPageTest()
        {
            bool loginStatusExpected = true;
         
            // 1. Login to Authorization Page
            AuthorizationPage authorizationPage = yandexPage.GoToAuthorizationPage();

            // 2. Input username and password on Authorization Page
            authorizationPage.InputCredentials(credentialsConstants.UserName, credentialsConstants.Password);
         
            // 3. Log out to Authorization Page
            yandexPage.LogOutToYandexPage();
 
            bool logOutStatusActual = yandexPage.IsLogOutAuthorizationPage();

            // 1. Verify that the Authorization page is logged out 
            Assert.AreEqual(loginStatusExpected, logOutStatusActual, "The Authorization page isn't logged out!!!");
        }

        private void InitializeCredentials()
        {
            new CredentialsProvider().Provide(out CredentialsConstants credentialsConstantsObject);
            credentialsConstants = credentialsConstantsObject;
        }
    }
}