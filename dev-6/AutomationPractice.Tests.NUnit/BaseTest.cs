using AutomationPracticeTests.Utilities.Logger;
using AutomationPracticeTests.WebDriver.Factory;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace AutomationPracticeTests.BaseTests
{
     [SetUpFixture]
     public class BaseTest
     {
        public Browser Browser { get; private set; } 

        public Utilities.Logger.Logger Log { get; private set; }

        [OneTimeSetUp]
        public virtual void InitTest()
        {
            Log = LoggerManager.GetLogger(this.GetType());
            Log.Info("Browser SetUp");

            Browser = Browser.Instance;
            //Browser.WindowMaximise();
        }

        [SetUp]
        public void RunBeforeEachTest() { }

        [TearDown]
        public void RunAfterEachTest()
        {
            if(TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                //TestContext.AddTestAttachment(S)
            }
        }

        [OneTimeTearDown]
        public virtual void Quit()
        {
            Log.Info("Browser TearDown");
            Browser.Quit();
        }
     }
}
