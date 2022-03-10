using AutomationPracticeTests.CustomComponents;
using AutomationPracticeTests.PageObjects.BasePages;
using OpenQA.Selenium;

namespace AutomationPracticeTests.PageObjects.Pages
{
    public class CartPage : BasePage
    {
        private BaseWebElement CountProductsSpan => new BaseWebElement(By.Id("summary_products_quantity"));

        private BaseWebElement TotalProductsSpan => new BaseWebElement(By.Id("total_price"));

        public CartPage() : base("Order - My Store") {}

        public string GetCountProductsInCart()
        {
            return CountProductsSpan.GetText();
        }

        public string GetTotalProductsInCart()
        {
            return TotalProductsSpan.GetText();
        }
    }
}
