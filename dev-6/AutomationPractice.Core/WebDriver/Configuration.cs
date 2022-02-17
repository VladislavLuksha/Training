using AutomationPracticeTests.Utilities.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace AutomationPracticeTests.WebDriver.Factory
{
    public static class Configuration
    {
        public static readonly string Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
       
        public static ConfigurationModel Instance => new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build().Get<ConfigurationModel>();

        public static IConfiguration Builder => new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{Env}.json", true, true)
            .Build();

        //public static BrowserType TestBrowser
        //{
        //    get
        //    {
        //        var setting = Builder[""];
        //    }
        //}


        public static Uri RemoteWebDriverHub
        {
            get
            {
                string setting = Builder["RemoteWebDriverHub"];
                return new Uri(setting);
            }
        }

        public static NameValueCollection GetNameValueSectionFromAppsettingsJson(string preferences)
        {
            NameValueCollection preferencesCollection = new NameValueCollection();
            var jsonSettings = Builder.GetSection(preferences).Get<Dictionary<string, string>>();

            if (jsonSettings == null)
            {
                return preferencesCollection;
            }

            foreach(var k in jsonSettings)
            {
                string value = null;

                if (k.Value != null)
                {
                    value = k.Value.ToString();
                }

                preferencesCollection.Add(k.Key.ToString(), value);
            }

            return preferencesCollection;
        }

        public static BrowserType TestBrowserCapabilities
        {
            get
            {
                bool supportedBrowser = false;
                var setting = Builder["DriverCapabilities"];
                supportedBrowser = Enum.TryParse(setting, out BrowserType browserType);

                if (supportedBrowser)
                    return browserType;

                return BrowserType.None;
            }
        }
    }
}
