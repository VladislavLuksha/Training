using AutomationPracticeTests.CustomComponents;
using AutomationPracticeTests.CustomComponents.WebElements;
using AutomationPracticeTests.PageObjects.BasePages;
using OpenQA.Selenium;

namespace AutomationPracticeTests.PageObjects.Pages
{
    public class MyWishlistsPage : BasePage
    {
        public MyWishlistsPage() : base() { }

        public BaseWebElement MyWishlistBlock => new BaseWebElement(By.Id("block-history"));

        public BaseWebElement MyWishlistName { get; set; }

        public BaseWebElement ProductElement => new BaseWebElement(By.XPath("//ul[@class = 'row wlp_bought_list']/li"));

        public BaseWebElement MyWishlistDelete => new BaseWebElement(By.CssSelector(".wishlist_delete .icon"));

        public Inputs InputWishlistName => new Inputs("name");

        public Buttons ButtonSave => new Buttons("submitWishlist");

        public bool InvisibilityOfWishlistElement()
        {
            return MyWishlistBlock.Invisibility;
        }

        public bool IsWishlistCreated(string wishlistName)
        {
            MyWishlistName = new BaseWebElement(By.XPath(string.Format("//a[contains(text(),'{0}')]", wishlistName)));

            return MyWishlistName.Displayed;
        }

        public bool IsProductExists()
        {
            return ProductElement.Displayed;
        }

        public void ClickMyWishlistsButton(string wishlistName)
        {
            MyWishlistName = new BaseWebElement(By.XPath(string.Format("//a[contains(text(),'{0}')]", wishlistName)));

            MyWishlistName.Click();
        }

        public void DeleteMyWishlists()
        {
            MyWishlistDelete.Click();
            JavaScriptAlert.ConfirmJavaScriptAlert();
        }

        public MyWishlistsPage FillInputNewWishlist(string wishlistName)
        {
            InputWishlistName.TypeText(wishlistName);

            return this;
        }

        public void ClickSaveButton()
        {
            ButtonSave.Click();
        }
    }
}
