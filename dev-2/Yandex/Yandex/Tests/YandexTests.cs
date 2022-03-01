using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            yandexPage.GoTo();
        }

        [Test]
        public void IsTrueSingingInTest()
        {
            bool expected = true;

            // 1. Navigate on authorization page.
            yandexPage.NavigateOnAuthorizationPage();
            authorizationPage.LoginAuthorizationPage();
            bool isTrueSingingIn = authorizationPage.isLoginAuthorizationPage();

            // 1. Checking if you're signed in.
            Assert.AreEqual(expected, isTrueSingingIn, "Login failed!");
        }

        [TearDown]
        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}