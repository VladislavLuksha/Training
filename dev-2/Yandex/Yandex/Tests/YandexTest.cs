using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Yandex.Pages;

namespace Yandex
{
    public class YandexTest 
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
            var expected = true;

            // 1. Navigate on authorization page.
            yandexPage.NavigateOnAuthorizationPage();
          
            var isTrueSingingIn = authorizationPage.isLoLoginAuthorizationPage();

            // 1. Checking if you're signed in.
            Assert.AreEqual(expected, isTrueSingingIn, "Login failed!");
        }

        [TearDown]
        public void CloseBrowser()
        {
            Driver.Close();
        }
    }
}