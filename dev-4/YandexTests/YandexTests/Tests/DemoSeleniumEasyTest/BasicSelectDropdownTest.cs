using NUnit.Framework;
using YandexTests.Pages;

namespace YandexTests.Tests
{
    [TestFixture]
    public class BasicSelectDropdownTest : BaseTest
    {
        private BasicSelectDropdownPage demoSeleniumEasyPage;
        
        [SetUp]
        public void InitializeDemoSeleniumEasyTest()
        {
            demoSeleniumEasyPage = new BasicSelectDropdownPage(Driver);
            demoSeleniumEasyPage.GoTo();
        }

        [Test]
        public void CheckOptionsSelectedTest()
        {
            int expectedOptions = 3;
           
            // 1. Select 3 random options in “Multi Select List Demo” section
            var actualSelectedOptions = demoSeleniumEasyPage.ChooseRandomOptions();

            // 1. Verify that 3 random options are selected
            Assert.AreEqual(expectedOptions, actualSelectedOptions.Count, "3 options aren't selected!");
        }
    }
}
