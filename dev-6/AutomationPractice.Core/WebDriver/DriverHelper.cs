using AutomationPracticeTests.Utilities.Enums;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace AutomationPracticeTests.WebDriver.Factory
{
    public static class DriverHelper
    {
        public static IWebElement FindElement(By locator)
        {
            try
            {
                return Browser.Wait.Until<IWebElement>((d) =>
                {
                    IWebElement element = d.FindElement(locator);

                    if(element.Displayed &&
                       element.Enabled &&
                       element.GetAttribute("aria-disabled") == null)
                    {
                        return element;
                    }

                    return null;
                });
            }
            catch (TimeoutException)
            {
                return null;
            }
        }

        public static IList<IWebElement> FindElements(By locator)
        {
            try
            {
                return Browser.Wait.Until(d => d.FindElements(locator));
            }
            catch (TimeoutException)
            {
                return null;
            }
        }

        public static IWebElement FindSelectElement(By locator)
        {
            try
            {
                return Browser.Wait.Until<IWebElement>((d) =>
                {
                    IWebElement element = d.FindElement(locator);
    
                    return element;
                });
            }
            catch (TimeoutException)
            {
                return null;
            }
        }
        
        public static void ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Browser.Driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        //public static bool InvisibilityOfElementLocated(By locator)
        //{
        //    try
        //    {
        //        IWebElement element = Browser.Driver.FindElement(locator);

        //        return !element.Displayed;
        //    }
        //    catch(NoSuchElementException)
        //    {
        //        return true;
        //    }
        //    catch (WebDriverTimeoutException)
        //    {
        //        return true;
        //    }
        //    catch (StaleElementReferenceException)
        //    {
        //        return true;
        //    }
        //}

        public static bool InvisibilityOfElementLocated(By locator)
        {
            return Browser.Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public static void SetRemoteDriverBrowserOptions(dynamic browsersOptions)
        {
            Dictionary<string, object> capabilities = new Dictionary<string, object> {
                ["username"] = SauceUserName,
                ["accessKey"] = SauceAccessKey
            };

            if(Configuration.RemoteWebDriverHub.ToString().ToLower().Contains("saucelabs"))
            {
                browsersOptions.AddAdditionalOption("sauce:options", capabilities);
            }
            else if(Configuration.RemoteWebDriverHub.ToString().ToLower().Contains("selenoid"))
            {
                browsersOptions.AddAdditionalOption("selenoid:options", capabilities);
            }
        }

        public static BrowserType GetBrowserTypeForRemoteDriver(NameValueCollection settings)
        {
            BrowserType browserType = BrowserType.None;
            
            if(settings != null)
            {
                string browser = settings.GetValues("browser")?[0];
                Enum.TryParse(browser, out browserType);
            }

            return browserType;
        }

        private static string SauceUserName =>
          Environment.GetEnvironmentVariable("SAUCE_USERNAME");

        private static string SauceAccessKey =>
            Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY");
    }
}
