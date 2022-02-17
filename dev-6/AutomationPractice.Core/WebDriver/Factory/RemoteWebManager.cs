using AutomationPractice.Core.Helpers;
using AutomationPracticeTests.Utilities.Enums;
using AutomationPracticeTests.WebDriver.Factory;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace AutomationPractice.Core.WebDriver.Factory
{
    public class RemoteWebManager : BaseDriverManager
    {
        public RemoteWebManager() : base() { }


        public override IWebDriver GetDriver(double timeoutSec)
        {
            IWebDriver driver = null;

            var driverCapabilitiesConf = Configuration.GetNameValueSectionFromAppsettingsJson("DriverCapabilities");
            var setting = Configuration.GetNameValueSectionFromAppsettingsJson("environments:" + CrossBrowserEnvironment);
         
            var browserType = DriverHelper.GetBrowserTypeForRemoteDriver(setting);

            switch (browserType)
            {
                case BrowserType.Chrome:
                    ChromeOptions = new ChromeOptions();
                    DriverHelper.SetRemoteDriverBrowserOptions(driverCapabilitiesConf, setting, ChromeOptions);
                    driver = new RemoteWebDriver(Configuration.RemoteWebDriverHub, ChromeOptions.ToCapabilities());
                    break;
                case BrowserType.Firefox:
                    FirefoxOptions = new FirefoxOptions();
                    DriverHelper.SetRemoteDriverBrowserOptions(driverCapabilitiesConf, setting, FirefoxOptions);
                    driver = new RemoteWebDriver(Configuration.RemoteWebDriverHub, FirefoxOptions.ToCapabilities());
                    break;
                //case BrowserType.IE:
                //    ChromeOptions = new ChromeOptions();
                //    DriverHelper.SetRemoteDriverBrowserOptions(setting, ChromeOptions);
                //    driver = new RemoteWebDriver(Configuration.RemoteWebDriverHub, ChromeOptions.ToCapabilities());
                //    break;
                //case BrowserType.Edge:
                //    ChromeOptions = new ChromeOptions();
                //    DriverHelper.SetRemoteDriverBrowserOptions(setting, ChromeOptions);
                //    driver = new RemoteWebDriver(Configuration.RemoteWebDriverHub, ChromeOptions.ToCapabilities());
                //    break;
            }

            return driver;
        }
    }
}
