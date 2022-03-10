using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationPracticeTests.WebDriver.Factory
{
    public class ChromeManager : BaseDriverManager
    {
        public ChromeManager() : base(ChromeDriverService.CreateDefaultService(), new ChromeOptions())
        {
            
        }

        public override IWebDriver GetDriver(double timeoutSec) =>
            new ChromeDriver(ChromeDriverService, ChromeOptions, TimeSpan.FromSeconds(timeoutSec));
    }
}
