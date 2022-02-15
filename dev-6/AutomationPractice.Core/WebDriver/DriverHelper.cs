using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
    }
}
