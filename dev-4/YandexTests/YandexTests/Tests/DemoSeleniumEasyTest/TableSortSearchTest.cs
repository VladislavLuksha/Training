using NUnit.Framework;
using YandexTests.Pages;
using System.Collections.Generic;

namespace YandexTests.Tests
{
    [TestFixture]
    public class TableSortSearchTest : BaseTest
    {
        private TableSortSearchPage tableSortSearchPage;

        [SetUp]
        public void InitializeTableSortSearchTest()
        {
            tableSortSearchPage = new TableSortSearchPage(Driver);
            tableSortSearchPage.GoTo();
        }

        [Test]
        public void ReturnsListOfYourCustomObjectTest()
        {
            int expected = 16;
            string option = "100";
            int minAge = 30;
            int maxSalary = 400000;

            // 1. Select "100" option in dropdown “Show () entries”
            tableSortSearchPage.SelectOptionInDropDown(option);

            // 2. Returns list of your custom objects with age > x and salary <= y for all pages
            List<CustomModel> listCustom =  tableSortSearchPage.ReturnsListOfCustomObjects(minAge, maxSalary);

            // 1. Verify that returned list of your custom objects with age > x and salary <= y for all pages
            Assert.AreEqual(expected, listCustom.Count, "Method did not return all Custom objects!");
        }
    }
}
