using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using YandexTests.Pages;


namespace YandexTests.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver Driver { get; set; }

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void Cleanup()
        {
            Driver.Quit();
        }
    }
}
