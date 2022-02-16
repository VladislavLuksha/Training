using AutomationPracticeTests.CustomComponents;
using AutomationPracticeTests.CustomComponents.WebElements;
using AutomationPracticeTests.PageObjects.BasePages;
using AutomationPracticeTests.WebDriver.Factory;
using OpenQA.Selenium;

namespace AutomationPracticeTests.PageObjects.Pages
{
    public class WomenPage : BasePage
    {
        public WomenPage() : base() { }

        public BaseWebElement Product => new BaseWebElement(By.CssSelector(".right-block .product-name"));

        public BaseWebElement AddToWishlistButton => new BaseWebElement(By.Id("wishlist_button"));

        public BaseWebElement AddToCartButton => new BaseWebElement(By.Id("//a[@title = 'Add to cart']"));

        public Table ProductTable => new Table("product-container");

        public WomenPage ChooseAnyProduct()
        { 
            Product.Click();
            
            return this;
        }

        public void AddThreeDifferentProducts()
        {
            //AddToCartButton.Click();
            //Browser.Driver.FindElement(By.Id("page")).Click();
            //ProductTable.GetTable();
        }

        public void ClickAddToWishlistButton()
        {
            AddToWishlistButton.Click();
            Browser.Driver.FindElement(By.Id("page")).Click();
        }
    }
}
