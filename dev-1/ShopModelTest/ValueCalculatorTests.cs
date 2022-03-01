using Core;
using NUnit.Framework;
using System.Collections.Generic;

namespace ShopModelTests
{
    [TestFixture]
    public class ValueCalculatorTests
    {
        private ValueCalculator valueCalculator;

        [SetUp]
        public void Setup()
        {
            valueCalculator = new ValueCalculator();
        }

        [Test]
        public void ValueCalcTest()
        {
            var products = new List<Product>() 
            {
                new Product() { Name = "BMW", Price = 10000, ProductID = 1 },
                new Product() { Name = "audi", Price = 11000, ProductID = 2 },
                new Product() { Name = "lada", Price = 9000, ProductID = 3 }
            };
            decimal sumOfProductsExpected = 30000;
            decimal sumOfProducts = valueCalculator.ValueCalc(products);

            Assert.AreEqual(sumOfProductsExpected, sumOfProducts, "The sum of the products isn't correct!");
        }
    }
}