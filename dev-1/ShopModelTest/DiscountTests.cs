﻿using Core.Discounts;
using NUnit.Framework;

namespace ShopModelTests
{
    [TestFixture]
    public class DiscountTests
    {
        Discount_1 discount_1 = new Discount_1();
        Discount_5 discount_5 = new Discount_5();
        const decimal value = 10;

        [Test]
        public void DiscountOneTest()
        {
            decimal valueExpected = 9.9m;
            decimal percentageValue = discount_1.PercentageValue(value);

            Assert.AreEqual(valueExpected, percentageValue, "Result percentage of value isn't correct!");
        }

        [Test]
        public void DiscountFiveTest()
        {
            decimal valueExpected = 9.5m;
            decimal percentageValue = discount_5.PercentageValue(value);

            Assert.AreEqual(valueExpected, percentageValue, "Result percentage of value isn't correct!");
        }
    }
}
