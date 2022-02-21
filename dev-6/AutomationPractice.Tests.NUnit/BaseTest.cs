using AutomationPractice.Core.Helpers;
using AutomationPracticeTests.Utilities.Logger;
using AutomationPracticeTests.WebDriver.Factory;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using System;
using System.IO;

namespace AutomationPracticeTests.BaseTests
{
     [SetUpFixture]
     public class BaseTest
     {
        public BaseTest() { }

        public BaseTest(string environment)
        { 
            BaseDriverManager.CrossBrowserEnvironment = environment;
        }

        public Browser Browser { get; private set; } 

        public Utilities.Logger.Logger Log { get; private set; }

        public string ScreenshotsDirectory { get; private set; }

        [OneTimeSetUp]
        public virtual void RunBeforeEachClass()
        {
            Log = LoggerManager.GetLogger(this.GetType());
            Log.Info("Browser SetUp");
            ScreenshotsDirectory = Path.Combine(Environment.CurrentDirectory, "target/attachments/screenshots");

            Browser = Browser.Instance;
            Browser.WindowMaximise();
        }

        [OneTimeTearDown]
        public virtual void RunAfterEachClass()
        {
            Log.Info("Browser TearDown");
            Browser.QuitDriver();
            
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
