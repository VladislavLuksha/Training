using AutomationPractice.Core.WebDriver.Factory;
using AutomationPracticeTests.Utilities.Enums;
using OpenQA.Selenium;
using System;

namespace AutomationPracticeTests.WebDriver.Factory
{
    public class BrowserFactory
    {
        public static IWebDriver GetDriver(BrowserType type, double timeoutSec)
        {
            IWebDriver driver = null;

            switch (type)
            {
                case BrowserType.Chrome:
                    {
                        ChromeManager chromeManager = new ChromeManager();
                        driver = chromeManager.GetDriver(timeoutSec);
                        break;
                    }
                case BrowserType.Firefox:
                    {
                        FirefoxManager firefoxManager = new FirefoxManager();
                        driver = firefoxManager.GetDriver(timeoutSec);
                        break;
                    }
                case BrowserType.RemoteWebDriver:
                    {
                        RemoteWebManager remoteWebManager = new RemoteWebManager();
                        driver = remoteWebManager.GetDriver(timeoutSec);
                        break;
                    }
                default:
                    throw new ArgumentException($"{type} not supported");
            }

            return driver;
        }

    }
}
