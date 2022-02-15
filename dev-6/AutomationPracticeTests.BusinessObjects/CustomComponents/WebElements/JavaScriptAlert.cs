using AutomationPracticeTests.WebDriver.Factory;

namespace AutomationPracticeTests.CustomComponents.WebElements
{
    public static class JavaScriptAlert
    {
        static public void ConfirmJavaScriptAlert()
        {
            Browser.Driver.SwitchTo().Alert().Accept();
            Browser.Driver.SwitchTo().DefaultContent();
        }
    }
}
