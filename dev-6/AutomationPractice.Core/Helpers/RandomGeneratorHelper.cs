using System;
using System.Linq;

namespace AutomationPracticeTests.Utilities
{
    public class RandomGeneratorHelper
    {
        private static string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private static string emailFormat = "@gmail.com";

        private static Random Random => new Random();

        public static string GetRandomString(int length)
        {
            string result = new string(
                Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)])
                .ToArray());
            return result;
        }

        public static string GetRandomEmailString(int length)
        {
            var randomString = GetRandomString(length);
            return String.Format("{0}{1}", randomString, emailFormat);
        }
    }
}
