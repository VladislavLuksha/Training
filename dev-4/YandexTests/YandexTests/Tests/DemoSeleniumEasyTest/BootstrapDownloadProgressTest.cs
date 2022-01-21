using OpenQA.Selenium;
using YandexTests.Pages;
using NUnit.Framework;

namespace YandexTests.Tests
{
    public class BootstrapDownloadProgressTest : BaseTest
    {
        private  BootstrapDownloadProgressPage bootstrapDownloadProgressPage;

        [SetUp]
        public void InitializeBootstrapDownloadProgressTest()
        {
            bootstrapDownloadProgressPage = new BootstrapDownloadProgressPage(Driver);
            bootstrapDownloadProgressPage.GoTo();
        }

        [Test]
        public void RefreshPageWhenPercentageMoreOrEqual_50_Test()
        {
            bool expected = true;

            // 1. Click Download button
            IWebElement downloadButton = bootstrapDownloadProgressPage.WaitingForElement(bootstrapDownloadProgressPage.downloadButton);
            downloadButton.Click();

            // 2. Refresh page when percentage is >= 50
            bool actual = bootstrapDownloadProgressPage.IsRefreshedPageWhenPercentageMoreOrEqual_50();

            // 1. Verify that page refreshed when percentage is >= 50
            Assert.AreEqual(expected, actual, "Page not reloaded!");
        }
    }
}
