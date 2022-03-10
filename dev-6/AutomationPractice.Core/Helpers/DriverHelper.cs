using AutomationPractice.Core.WebDriver;
using AutomationPracticeTests.Utilities.Enums;
using AutomationPracticeTests.WebDriver.Factory;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace AutomationPractice.Core.Helpers
{
    public static class DriverHelper
    {
        public static BrowserType GetBrowserTypeForRemoteDriver(NameValueCollection settings)
        {
            if (Configuration.TestBrowserCapabilities != BrowserType.CloudProvider)
                return Configuration.TestBrowserCapabilities;

            BrowserType browserType = BrowserType.None;

            if (settings != null)
            {
                string browser = settings.GetValues("browser")?[0];
                Enum.TryParse(browser, out browserType);
            }

            return browserType;
        }

        public static void SetRemoteDriverBrowserOptions(NameValueCollection driverCapabilitiesConf, NameValueCollection settings, dynamic browsersOptions)
        {
            Dictionary<string, object> capabilities = new Dictionary<string, object>();

            if (settings != null)
            {
                foreach (string key in settings.AllKeys)
                {
                    if (Configuration.RemoteWebDriverHub.ToString().ToLower().Contains("4444") && key == "os")
                    {
                        capabilities.Add(key, settings[key]);
                    }
                    else
                    {
                        capabilities.Add(key, settings[key]);
                    }
                }
            }

            if (Configuration.RemoteWebDriverHub.ToString().ToLower().Contains("saucelabs"))
            {
                capabilities.Add("username", SauseUser.SauceUserName);
                capabilities.Add("accessKey", SauseUser.SauceAccessKey);
                browsersOptions.AddAdditionalOption("sauce:options", capabilities);
            }
            else if (Configuration.RemoteWebDriverHub.ToString().ToLower().Contains("4444"))
            {
                capabilities.Add("enableVNC", true);
                browsersOptions.AddAdditionalOption("selenoid:options", capabilities);
            }
        }
    }
}
