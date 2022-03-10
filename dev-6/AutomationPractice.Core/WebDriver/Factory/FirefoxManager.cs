using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace AutomationPracticeTests.WebDriver.Factory
{
    public class FirefoxManager : BaseDriverManager 
    {
        public FirefoxManager() : base(FirefoxDriverService.CreateDefaultService(), new FirefoxOptions())
        {
        }

        public override IWebDriver GetDriver(double timeoutSec) =>
            new FirefoxDriver(FirefoxDriverService, FirefoxOptions, TimeSpan.FromSeconds(timeoutSec));
    }
}
