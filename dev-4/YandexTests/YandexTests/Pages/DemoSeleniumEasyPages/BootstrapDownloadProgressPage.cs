using OpenQA.Selenium;

namespace YandexTests.Pages
{
    public class BootstrapDownloadProgressPage : BasePage
    {
        private const int PERCENTAGE = 50;
        private readonly By downloadButton = By.Id("cricle-btn");
        private readonly By percentTextInput = By.XPath("//div[@class='percenttext' and contains(text(), '50%')]");

        protected override string Url => "https://demo.seleniumeasy.com/bootstrap-download-progress-demo.html";

        public BootstrapDownloadProgressPage(IWebDriver driver) : base(driver)
        {

        }

        public bool IsRefreshedPageWhenPercentageMoreOrEqual_50()
        {
            var element = WaitingForElement(percentTextInput);
        
            return element.Displayed;
        }

        public void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }

        public void ClickOnDownloadButton()
        {
            NavigateOnButton(downloadButton);
        }
    }
}
