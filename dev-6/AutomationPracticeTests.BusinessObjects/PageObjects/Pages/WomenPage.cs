using AutomationPracticeTests.BusinessObjects.CustomComponents.WebElements;
using AutomationPracticeTests.CustomComponents;
using AutomationPracticeTests.PageObjects.BasePages;
using AutomationPracticeTests.WebDriver.Factory;
using OpenQA.Selenium;

namespace AutomationPracticeTests.PageObjects.Pages
{
    public class WomenPage : BasePage
    {
        public WomenPage() : base("Women - My Store") { }

        public BaseWebElement AddToWishlistButton => new BaseWebElement(By.Id("wishlist_button"));

        public BaseWebElement AddToCartButton => new BaseWebElement(By.XPath("//span[text() = 'Add to cart']"));

        private BaseWebElements WomenProductsLinks => new BaseWebElements(By.CssSelector(".right-block .product-name"));

        public IWebElement GetAnyProduct(int position)
        {
            var products = WomenProductsLinks.GetElements();
            return products[position];
        }

        public void AddDifferentProductsToCart(int productsCount)
        {
            for (int i = 0; i < productsCount; i++)
            {
                var product = GetAnyProduct(i);
                product.Click();
                AddToCartButton.Click();
                Browser.Driver.Navigate().Back();
            }
        }

        public void AddDifferentProductsToWishlist(int productsCount)
        {
            for (int i = 0; i < productsCount; i++)
            {
                var product = GetAnyProduct(i);
                product.Click();
                AddToWishlistButton.Click();
                Browser.Driver.Navigate().Back();
            }
        }
    }
}
