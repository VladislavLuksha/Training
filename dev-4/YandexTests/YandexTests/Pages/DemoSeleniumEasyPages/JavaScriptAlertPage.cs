using OpenQA.Selenium;

namespace YandexTests.Pages
{
    public class JavaScriptAlertPage: BasePage
    {
        public readonly By clickButtonForConfirmBox = By.XPath("//p[@id = 'confirm-demo']/preceding-sibling::button");
        public readonly By clickButtonForAlertBox = By.XPath("//div[text()='Java Script Alert Box']/following-sibling::div/button[text()='Click me!']");
        public readonly By confirmInput = By.Id("confirm-demo");
        public readonly By clickForPromptBoxButton = By.XPath("//button[text()='Click for Prompt Box']");
        public readonly By promtInput = By.Id("prompt-demo");

        public JavaScriptAlertPage(IWebDriver driver) : base(driver)
        {

        }

        protected override string Url => "https://demo.seleniumeasy.com/javascript-alert-box-demo.html";

    }
}
