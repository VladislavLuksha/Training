using OpenQA.Selenium;

namespace Yandex.Utils
{
    public class AuthorizationLocators
    {
        public By userNameInput = By.Id("passp-field-login");
        public By loginButtonForAccount = By.Id("passp:sign-in");
        public By passwordInput = By.Id("passp-field-passwd");
        public By messageStatusField = By.XPath("//span[@class='username__first-letter']");

        public string userName = "vladik.luksha";  
        public string password = "Vl34567";
    }
}
