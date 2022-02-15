using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;

namespace AutomationPracticeTests.WebDriver.Factory
{
    public abstract class BaseDriverManager
    {
        protected ChromeOptions ChromeOptions { get; set; }

        protected FirefoxOptions FirefoxOptions { get; set; }

        public Dictionary<string, object> SauceOptions { get; set; }

        protected ChromeDriverService ChromeDriverService { get; set; }

        protected FirefoxDriverService FirefoxDriverService { get; set; }

        public string SauceUserName =>
            Environment.GetEnvironmentVariable("SAUCE_USERNAME");

        public string SauceAccessKey =>
            Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY");

        public BaseDriverManager(ChromeDriverService chromeDriverService, ChromeOptions chromeOptions)
        {
            ChromeDriverService = chromeDriverService;
            ChromeOptions = chromeOptions;

            //SauceOptions = new Dictionary<string, object>
            //{
            //    ["username"] = SauceUserName,
            //    ["accessKey"] = SauceAccessKey
            //};

            //ChromeOptions.AddAdditionalChromeOption("sauce:options", SauceOptions);
        }

        public BaseDriverManager(FirefoxDriverService firefoxDriverService, FirefoxOptions firefoxOptions)
        {
            FirefoxDriverService = firefoxDriverService;
            FirefoxOptions = firefoxOptions;
            //FirefoxOptions.AddAdditionalFirefoxOption("sauce:options", SauceOptions);
        }

        public abstract IWebDriver GetDriver(double timeoutSec);
    }
}
