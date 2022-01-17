using Core.Discounts;
using NUnit.Framework;

namespace ShopModelTests
{
    [TestFixture]
    public class DiscountTest
    {
        Discount_1 discount_1 = new Discount_1();
        Discount_5 discount_5 = new Discount_5();
        const decimal value = 10;

        [Test]
        public void DiscountOneTest()
        {
            decimal expected = 9.9m;
            decimal percentageValue = discount_1.PercentageValue(value);

            Assert.AreEqual(expected, percentageValue, "Result percentage of value isn't correct!");
        }

        [Test]
        public void DiscountFiveTest()
        {
            decimal expected = 9.5m;
            decimal percentageValue = discount_5.PercentageValue(value);

            Assert.AreEqual(expected, percentageValue, "Result percentage of value isn't correct!");
        }
    }
}
