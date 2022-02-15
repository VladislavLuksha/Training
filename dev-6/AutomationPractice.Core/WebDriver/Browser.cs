using AutomationPracticeTests.Utilities.Enums;
using AutomationPracticeTests.Utilities.Logger;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationPracticeTests.WebDriver.Factory
{
    public class Browser
    {
        private static BrowserType currentBrowser;

        private static Browser currentInstance;

        private Browser()
        {
            InitParams();
            Log = LoggerManager.GetLogger(GetType());
            Driver = BrowserFactory.GetDriver(currentBrowser, TimeoutForElement);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeoutForElement));
        }

        public static IWebDriver Driver { get; private set; }

        public static WebDriverWait Wait { get; private set; }

        public static Logger Log { get; private set; }

        public static double TimeoutForElement { get; private set; }

        public static Browser Instance => currentInstance ?? (currentInstance = new Browser());

        public static void WindowMaximise() => Driver.Manage().Window.Maximize();

        public static void NavigateTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
            Log.Info($"Page {url} is opened");
        }

        public static void Quit()
        {
            Driver.Quit();
            currentInstance = null;
            Driver = null;
        }

        private void InitParams()
        {
            TimeoutForElement = Convert.ToDouble(Configuration.Instance.ElementTimeout);
            Enum.TryParse(Configuration.Instance.Browser, out currentBrowser);
        }
    }
}
