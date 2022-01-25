using OpenQA.Selenium;

namespace YandexTests.Pages
{
    public class JavaScriptAlertPage: BasePage
    {
        private readonly By clickButtonForConfirmBox = By.XPath("//p[@id = 'confirm-demo']/preceding-sibling::button");
        private readonly By clickButtonForAlertBox = By.XPath("//div[text()='Java Script Alert Box']/following-sibling::div/button[text()='Click me!']");
        private readonly By confirmInput = By.Id("confirm-demo");
        private readonly By clickForPromptBoxButton = By.XPath("//button[text()='Click for Prompt Box']");
        private readonly By promtInput = By.Id("prompt-demo");

        protected override string Url => "https://demo.seleniumeasy.com/javascript-alert-box-demo.html";

        public JavaScriptAlertPage(IWebDriver driver) : base(driver)
        {

        }

        public void ClickOnButtonForConfirmBox()
        {
            NavigateOnButton(clickButtonForConfirmBox);
        }

        public void ClickOnButtonForAlertBox()
        {
            NavigateOnButton(clickButtonForAlertBox);
        }

        public void ClickOnForPromptBoxButton()
        {
            NavigateOnButton(clickForPromptBoxButton);
        }

        public string GetTextFromConfirmBox()
        {
            return WaitingForElement(confirmInput).Text;
        }

        public string GetTextFromPromptBox()
        {
            return WaitingForElement(promtInput).Text;
        }
    }
}
