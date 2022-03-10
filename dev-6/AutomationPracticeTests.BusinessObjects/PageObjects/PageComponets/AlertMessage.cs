using AutomationPracticeTests.CustomComponents;
using OpenQA.Selenium;

namespace AutomationPracticeTests.BusinessObjects.PageObjects.Componets
{
    public class AlertMessage
    {
        public BaseWebElement ErrorMessage => new BaseWebElement(By.XPath("//div[@class='alert alert-danger']//li"));

        public string GetErrorMessage()
        {
            return ErrorMessage.GetText();
        }
    }
}
