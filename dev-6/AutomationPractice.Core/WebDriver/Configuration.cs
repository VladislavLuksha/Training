using Microsoft.Extensions.Configuration;
using System;

namespace AutomationPracticeTests.WebDriver.Factory
{
    public class Configuration
    {
        public static readonly string Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        public static ConfigurationModel Instance => new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build().Get<ConfigurationModel>();
    }
}
