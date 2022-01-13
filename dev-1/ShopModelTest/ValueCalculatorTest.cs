using Core;
using NUnit.Framework;
using System.Collections.Generic;

namespace ShopModelTests
{
    [TestFixture]
    public class ValueCalculatorTest
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
            int expected = 30000;

            decimal sumOfProduct = valueCalculator.ValueCalc(products);

            Assert.AreEqual(expected, sumOfProduct, "The sum of the products is not correct!");
        }
    }
}