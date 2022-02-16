using AutomationPracticeTests.Utilities.Enums;
using AutomationPracticeTests.WebDriver.Factory;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Collections.Specialized;

namespace AutomationPractice.Core.WebDriver.Factory
{
    public class RemoteWebManager : BaseDriverManager
    {
        public RemoteWebManager() : base() { }

        public override IWebDriver GetDriver(double timeoutSec)
        {
            IWebDriver driver = null;
            var setting = Configuration.GetNameValueSectionFromAppsettingsJson("environments:" + "ChromeWindows") as NameValueCollection; 
         
            var browserType = DriverHelper.GetBrowserTypeForRemoteDriver(setting);

            switch (browserType)
            {
                case BrowserType.Chrome:
                    ChromeOptions = new ChromeOptions();
                    ChromeOptions.PlatformName = "ddd";
                    DriverHelper.SetRemoteDriverBrowserOptions(ChromeOptions);
                    ChromeOptions.BrowserVersion = "";
                    driver = new RemoteWebDriver(Configuration.RemoteWebDriverHub, ChromeOptions);
                    break;
            }

            return driver;
        }
           
    }
}
