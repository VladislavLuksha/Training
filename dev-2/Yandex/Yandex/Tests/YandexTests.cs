using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Yandex.Entities;
using Yandex.Enums;
using Yandex.Pages;

namespace Yandex
{
    public class YandexTests 
    {
        public IWebDriver Driver { get; set; }

        private YandexPage yandexPage;
        private AuthorizationPage authorizationPage;

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            yandexPage = new YandexPage(Driver);
            authorizationPage = new AuthorizationPage(Driver);
        }

        [Test]
        public void IsTrueSingingInTest()
        {
            bool expected = true;
            var user = UserCreator.GetUser(UserType.ChromeUser);
       
            // 1. Got to Yandex 
            yandexPage.GoTo();

            // 2. Navigate on authorization page.
            yandexPage.NavigateOnAuthorizationPage();
            authorizationPage.LoginAuthorizationPage(user.Username, user.Password);
            bool isLoggedInActual  = authorizationPage.isLoginAuthorizationPage();

            // 1. Checking if you're signed in.
            Assert.AreEqual(expected, isLoggedInActual , "Login failed!");
        }

        [TearDown]
        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}