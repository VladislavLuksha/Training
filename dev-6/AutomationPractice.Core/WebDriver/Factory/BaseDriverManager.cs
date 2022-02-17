using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace AutomationPracticeTests.WebDriver.Factory
{
    public abstract class BaseDriverManager
    {
        protected ChromeOptions ChromeOptions { get; set; }

        protected FirefoxOptions FirefoxOptions { get; set; }

        protected ChromeDriverService ChromeDriverService { get; set; }

        protected FirefoxDriverService FirefoxDriverService { get; set; }

        public static string CrossBrowserEnvironment { get; set; }

        public BaseDriverManager(ChromeDriverService chromeDriverService, ChromeOptions chromeOptions)
        {
            ChromeDriverService = chromeDriverService;
            ChromeOptions = chromeOptions;
        }

        public BaseDriverManager(FirefoxDriverService firefoxDriverService, FirefoxOptions firefoxOptions)
        {
            FirefoxDriverService = firefoxDriverService;
            FirefoxOptions = firefoxOptions;
        }

        public BaseDriverManager() 
        {
        }
        
        public abstract IWebDriver GetDriver(double timeoutSec);
    }
}
