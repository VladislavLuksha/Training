using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Patterns.Pages;
using Patterns.Providers;
using Patterns.Utils;

namespace Patterns
{
    [TestFixture]
    public class YandexTest
    {
        private IWebDriver driver;
        private YandexPage yandexPage;
        private CredentialsConstants credentialsConstants;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.yandex.by");
            driver.Manage().Window.Maximize();
            yandexPage = new YandexPage(driver);
            InitializeCredentials();
        }

        private void InitializeCredentials()
        {
            new CredentialsProvider().Provide(out CredentialsConstants credentialsConstantsObject);
            credentialsConstants = credentialsConstantsObject;
        }

        [Test]
        public void GoToAuthorizationPageTest()
        {
            bool loginStatusExpected = true;
         
            // 1. Login to Authorization Page
            AuthorizationPage authorizationPage = yandexPage.GoToAuthorizationPage();
      
            // 2. Input username and password on Authorization Page
            authorizationPage.InputCredentials(credentialsConstants.UserName, credentialsConstants.Password);

            bool loginStatusActual = yandexPage.IsLogInAuthorizationPage();

            // 1. Verify that the Authorization page is logged in 
            Assert.AreEqual(loginStatusExpected, loginStatusActual, "The Authorization page isn't logged in!!!");
        }

        [Test]
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
        
        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}