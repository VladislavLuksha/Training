using OpenQA.Selenium;

namespace AutomationPracticeTests.CustomComponents
{
    public class TopNavigation
    {
        public BaseWebElement LoggedUserTitle => new BaseWebElement(By.XPath("//a[@class = 'account']"));

        public BaseWebElement WomenLink => new BaseWebElement(By.XPath("//a[text() = 'Women']"));

        public BaseWebElement MyAccountLink => new BaseWebElement(By.ClassName("account"));

        public BaseWebElement CartElement => new BaseWebElement(By.XPath("//a[@title = 'View my shopping cart']"));
    }
}
