using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using Patterns.Helpers;

namespace Patterns.Tests
{
    [SetUpFixture]
    public class BaseTest
    {
        protected string ScreenshotsDirectory { get; private set; }

        public static IWebDriver Driver { get; set; }

        [OneTimeSetUp]
        public virtual void RunBeforeEachClass()
        {
            ScreenshotsDirectory = Path.GetFullPath("../../../Utils/Screenshots");
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public virtual void RunAfterEachClass()
        {
            Driver.Quit();
        }

        [SetUp]
        public void RunBeforeEachTest()
        {
        }

        [TearDown]
        public void RunAfterEachTest()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                TestContext.AddTestAttachment(ScreenshotTakerHelper.TakeScreenshot(ScreenshotsDirectory, TestContext.CurrentContext.Test.Name));
            }
        }
    }
}
