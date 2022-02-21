using AutomationPracticeTests.CustomComponents;
using AutomationPracticeTests.PageObjects.BasePages;
using OpenQA.Selenium;

namespace AutomationPracticeTests.PageObjects.Pages
{
    public class MyAccountPage : BasePage
    {
        public MyAccountPage() : base("My account - My Store") { }

        public BaseWebElement MyWishlistsElement => new BaseWebElement(By.XPath("//li[@class = 'lnk_wishlist']/a"));

        public MyWishlistsPage GoToMyWishlistsPage()
        {
            MyWishlistsElement.Click();
            return new MyWishlistsPage();
        }

        public bool IsLoggedMyAccountPage()
        {
            return TopNavigation.LoggedUserTitle.Displayed;
        }
    }
}
