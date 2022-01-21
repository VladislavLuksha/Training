using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace YandexTests.Pages
{
    public class BasicSelectDropdownPage : BasePage
    {
        private const int START_POSITION = 0;
        private const int NUMBER_OF_OPTIONS = 3;
        private readonly By selectOptions = By.CssSelector("select#multi-select");

        public BasicSelectDropdownPage(IWebDriver driver) : base(driver)
        {

        }

        public IList<IWebElement> ChooseRandomOptions()
        {
            Random random = new Random();
            var selectElement = WaitingForElement(selectOptions);
            SelectElement select = new SelectElement(selectElement);
            var options = select.Options;

            for (int i = 0; i < NUMBER_OF_OPTIONS; i++)
            {
                int value = random.Next(START_POSITION, options.Count);
                options[value].Click();
            }

            return select.AllSelectedOptions;
        }

        protected override string Url => "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";
    }
}
