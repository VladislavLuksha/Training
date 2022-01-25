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
            bool statusPercentageInputExpected = true;

            // 1. Click Download button
            bootstrapDownloadProgressPage.ClickOnDownloadButton();

            // 2. Refresh page when percentage is >= 50
            bool statusPercentageInputActual = bootstrapDownloadProgressPage.IsRefreshedPageWhenPercentageMoreOrEqual_50();

            // 1. Verify that page refreshed when percentage is >= 50
            Assert.AreEqual(statusPercentageInputExpected, statusPercentageInputActual, "Page not reloaded!");
        }
    }
}
