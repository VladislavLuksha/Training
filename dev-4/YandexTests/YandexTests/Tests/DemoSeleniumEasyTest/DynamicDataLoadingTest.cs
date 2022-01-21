using NUnit.Framework;
using OpenQA.Selenium;
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
            bool expected = true;

            // 1. Click Get New User button
            IWebElement getNewUserButton = dynamicDataLoadingPage.WaitingForElement(dynamicDataLoadingPage.getNewUser);
            getNewUserButton.Click();

            // 2. Check if the user has arrived
            bool actual = dynamicDataLoadingPage.isUserWaited();

            // 3. Verify that the user waited
            Assert.AreEqual(expected, actual, "User is not found!");
        }
    }
}
