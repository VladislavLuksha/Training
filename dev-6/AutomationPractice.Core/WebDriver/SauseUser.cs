using System;

namespace AutomationPractice.Core.WebDriver
{
    public class SauseUser
    {
        public static string SauceUserName =>
         Environment.GetEnvironmentVariable("SAUCE_USERNAME");

        public static string SauceAccessKey =>
            Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY");
    }
}
