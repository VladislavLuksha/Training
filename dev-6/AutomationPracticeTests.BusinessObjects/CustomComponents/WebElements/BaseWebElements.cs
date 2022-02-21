using AutomationPractice.Core.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace AutomationPracticeTests.BusinessObjects.CustomComponents.WebElements
{
    public class BaseWebElements
    {
        protected IList<IWebElement> Elements { get; set; }

        protected By Locator { get; set; }

        protected string Name { get; set; }

        public BaseWebElements(By locator)
        {
            Locator = locator;
        }

        public IList<IWebElement> GetElements()
        {
            try
            {
                Elements = DriverExtensions.FindElements(Locator);
            }
            catch (Exception)
            {
                return null;
            }

            return Elements;
        }
    }
}
