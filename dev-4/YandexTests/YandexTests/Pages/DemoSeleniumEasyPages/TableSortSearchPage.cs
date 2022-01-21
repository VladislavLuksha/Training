using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace YandexTests.Pages
{
    public class TableSortSearchPage : BasePage
    {
        private readonly By showEntriesDropDown = By.CssSelector("[name='example_length']");
        private readonly By rowsTableLocator = By.XPath("//tbody/tr");
        private readonly By tagNameForRow = By.TagName("td");

        public TableSortSearchPage(IWebDriver driver) : base(driver)
        {

        }

        protected override string Url => "https://demo.seleniumeasy.com/table-sort-search-demo.html";

        public void SelectOptionInDropDown(string option)
        {
            var selectOptions = WaitingForElement(showEntriesDropDown);
            SelectElement selectElement = new SelectElement(selectOptions);
            var listOptions = selectElement.Options;

            foreach(var el in listOptions)
            {
                if(el.Text == option)
                {
                    el.Click();
                }
            }
        }

        public List<CustomModel> ReturnsListOfCustomObjects(int minAge, int maxSalary)
        {
            var listOfCustomObject = new List<CustomModel>();

            var rowsTable = GetRowsTable(rowsTableLocator);

            for (int i = 0; i < rowsTable.Count; i++)
            {
                var elementsOfRow = GetTheElementsOfRow(rowsTable[i], tagNameForRow);

                int age = Int32.Parse(elementsOfRow[3].Text);
                int salary = Int32.Parse(elementsOfRow[5].GetAttribute("data-order"));

                if (age > minAge && salary <= maxSalary)
                {
                    listOfCustomObject.Add(new CustomModel { Name = elementsOfRow[0].Text, Office = elementsOfRow[1].Text, Position = elementsOfRow[2].Text });
                }
            }

            return listOfCustomObject;
        }

        public IList<IWebElement> GetRowsTable(By rowsTable)
        {
            return Driver.FindElements(rowsTable);
        }

        public IList<IWebElement> GetTheElementsOfRow(IWebElement row, By tagNameForRow)
        {
            return row.FindElements(tagNameForRow);
        }
    }
}
