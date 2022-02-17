using AutomationPractice.Core.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.Drawing;

namespace AutomationPracticeTests.CustomComponents
{
    public class BaseWebElement : IWebElement
    {
        protected By Locator { get; set; }

        protected string Name { get; set; }

        protected IWebElement Element { get; set; }

        public BaseWebElement() { }

        public BaseWebElement(By locator, string name)
        {
            Locator = locator;
            Name = name == string.Empty ? GetText() : name;
        }

        public BaseWebElement(By locator)
        {
            Locator = locator;
        }

        public BaseWebElement(string name)
        {
            Name = name;
        }

        public string GetText() => GetElement().Text;
        
        public IWebElement GetElement()
        {
            try
            {
                Element = DriverExtensions.FindElement(Locator);
            }
            catch(Exception)
            {
                return null;
            }

            return Element;
        }

        public bool Displayed => GetElement()?.Displayed ?? false;

        public void Click()
        {
            GetElement().Click();
        }

        public bool Invisibility => DriverExtensions.InvisibilityOfElementLocated(Locator);

        public string TagName => throw new System.NotImplementedException();

        public string Text => throw new System.NotImplementedException();

        public bool Enabled => throw new System.NotImplementedException();

        public bool Selected => throw new System.NotImplementedException();

        public Point Location => throw new System.NotImplementedException();

        public Size Size => throw new System.NotImplementedException();

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public IWebElement FindElement(By by)
        {
            throw new System.NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            throw new System.NotImplementedException();
        }

        public string GetAttribute(string attributeName)
        {
            throw new System.NotImplementedException();
        }

        public string GetCssValue(string propertyName)
        {
            throw new System.NotImplementedException();
        }

        public string GetDomAttribute(string attributeName)
        {
            throw new System.NotImplementedException();
        }

        public string GetDomProperty(string propertyName)
        {
            throw new System.NotImplementedException();
        }

        public string GetProperty(string propertyName)
        {
            throw new System.NotImplementedException();
        }

        public ISearchContext GetShadowRoot()
        {
            throw new System.NotImplementedException();
        }

        public void SendKeys(string text)
        {
            throw new System.NotImplementedException();
        }

        public void Submit()
        {
            throw new System.NotImplementedException();
        }
    }
}
