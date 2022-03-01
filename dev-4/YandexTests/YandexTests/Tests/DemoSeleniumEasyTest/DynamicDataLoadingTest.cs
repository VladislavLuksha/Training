using NUnit.Framework;
using YandexTests.Pages;

namespace YandexTests.Tests
{
    [TestFixture]
    public class DynamicDataLoadingTest : BaseTest
    {
        private DynamicDataLoadingPage dynamicDataLoadingPage;

        [SetUp]
        public void InitializeDynamicDataLoadingTest()
        {
            dynamicDataLoadingPage = new DynamicDataLoadingPage(Driver);
            dynamicDataLoadingPage.GoTo();
        }

        [Test]
        public void WaitForUserTest()
        {
            bool isUserWaitedExpected = true;

            // 1. Click Get New User button
            dynamicDataLoadingPage.ClickOnGetNewUserButton();

            // 2. Check if the user has arrived
            bool isUserWaitedActual = dynamicDataLoadingPage.IsUserWaited();

            // 3. Verify that the user waited
            Assert.AreEqual(isUserWaitedExpected, isUserWaitedActual, "User is not found!");
        }
    }
}
