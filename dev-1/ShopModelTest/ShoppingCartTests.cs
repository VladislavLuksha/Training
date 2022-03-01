using Core;
using Core.Discounts;
using NUnit.Framework;
using System.Collections.Generic;

namespace ShopModelTests
{
    [TestFixture]
    public class ShoppingCartTests
    {
        ValueCalculator valueCalculator;
        Discount_1 discount_1;

        [SetUp]
        public void SetUp()
        {
            valueCalculator = new ValueCalculator();
            discount_1 = new Discount_1();
        }

        [Test]
        public void CalculateTotalTest()
        {
            var products = new List<Product>()
            {
                new Product() { Name = "BMW", Price = 10000, ProductID = 1 },
                new Product() { Name = "audi", Price = 11000, ProductID = 2 },
                new Product() { Name = "lada", Price = 9000, ProductID = 3 }
            };
            decimal expected = 29700;
            decimal total = discount_1.PercentageValue(valueCalculator.ValueCalc(products));

            Assert.AreEqual(expected, total, "Total isn't correct!");
        }
    }
}
