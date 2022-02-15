using AutomationPracticeTests.PageObjects.BasePages;
using AutomationPracticeTests.PageObjects.BasePages.Pages;
using AutomationPracticeTests.WebDriver.Factory;

namespace AutomationPracticeTests.PageObjects.Pages
{
    public class HomePage : BasePage
    {
        public HomePage() : base() { }

        public HomePage OpenHomePage()
        {
            Browser.NavigateTo(Configuration.Instance.HomePageUrl);
            return this;
        }

        public AuthenticationPage OpenAuthenticationPage()
        {
            Browser.NavigateTo(Configuration.Instance.AuthenticationPageUrl);

            return new AuthenticationPage();
        }

        public WomenPage GoToWomenPage()
        {
            TopNavigation.WomenLink.Click();

            return new WomenPage();
        }

        public MyAccountPage GoToMyWishlistsPage()
        {
            TopNavigation.MyAccountLink.Click();

            return new MyAccountPage();
        }
    }
}
