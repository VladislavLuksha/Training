using OpenQA.Selenium;

namespace YandexTests.Pages
{
    public class BootstrapDownloadProgressPage : BasePage
    {
        private const int PERCENTAGE = 50;
        public readonly By downloadButton = By.Id("cricle-btn");
        private readonly By percentTextInput = By.XPath("//div[@class='percenttext' and contains(text(), '50%')]");

        public BootstrapDownloadProgressPage(IWebDriver driver) : base(driver)
        {

        }

        protected override string Url => "https://demo.seleniumeasy.com/bootstrap-download-progress-demo.html";

        public bool IsRefreshedPageWhenPercentageMoreOrEqual_50()
        {
            WaitingForElement(percentTextInput);
        
            return true;
        }

        public void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }
    }
}
