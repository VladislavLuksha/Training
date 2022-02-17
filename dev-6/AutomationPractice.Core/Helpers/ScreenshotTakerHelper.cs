using AutomationPracticeTests.WebDriver.Factory;
using OpenQA.Selenium;
using System;
using System.Drawing.Imaging;
using System.IO;

namespace AutomationPractice.Core.Utilities
{
    public static class ScreenshotTakerHelper
    {
        public static string TakeScreenshot(string directory, string testName)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            string screenshotFileName =
                string.Format(
                    "{0}_{1}.{2}",
                    testName,
                    DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss"),
                    ImageFormat.Png.ToString().ToLowerInvariant());

            string screenshotSaveFullPath = Path.Combine(directory, screenshotFileName);

            if (Browser.Driver == null)
                throw new NullReferenceException();

            ((ITakesScreenshot)Browser.Driver).GetScreenshot().SaveAsFile(screenshotSaveFullPath, ScreenshotImageFormat.Png);

            return screenshotSaveFullPath;
        }
    }
}
