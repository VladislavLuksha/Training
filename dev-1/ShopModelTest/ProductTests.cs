using Core;
using NUnit.Framework;

namespace ShopModelTests
{
    [TestFixture]
    public class ProductTests
    {
        private Product productFirst;
        private Product productSecond;

        [SetUp]
        public void SetUp()
        {
            productFirst = new Product()
            {
                Name = "BMW",
                Price = 10000,
                ProductID = 1
            };

            productSecond = new Product()
            {
                Name = "Audi",
                Price = 10000,
                ProductID = 1
            };
        }

        [Test]
        public void ToStringTest()
        {
            string expected = $"Product ID: {productFirst.ProductID}, Name: {productFirst.Name}, Price: {productFirst.Price}";
            string resultString = productFirst.ToString();

            Assert.AreEqual(expected, resultString);
        }
        
        [Test]
        public void EqualsProductTest()
        {
            bool expectedFirst = false;
            bool expectedSecond = true;
            bool actualFirst = productFirst.Equals(productSecond);

            // Changing the property of the second object to test for equality with the first object.
            productSecond.Name = "BMW";
            bool actualSecond = productFirst.Equals(productSecond);

            // 1. Checks for different product objects
            Assert.AreEqual(expectedFirst, actualFirst, "This method is not overridden for Product class!");

            // 2. Checks for identical product objects
            Assert.AreEqual(expectedSecond, actualSecond, "This method is not overridden for Product class!");
        }

        [Test]
        public void OperatorEqualsTest()
        {
            bool expected = true;
            productSecond.Name = "BMW";
            bool actual = productFirst == productSecond;

            Assert.AreEqual(expected, actual, "Operator == isn't overriden for Product class!");
        }

        [Test]
        public void OperatorIsNotEqualsTest()
        {
            bool expected = true;
            bool actual = productFirst != productSecond;

            Assert.AreEqual(expected, actual, "Operator != isn't overriden for Product class!");
        }
    }
}
