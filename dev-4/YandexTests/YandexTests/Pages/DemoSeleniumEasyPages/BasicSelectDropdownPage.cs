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
        private readonly By selectOptions = By.Id("multi-select");

        protected override string Url => "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";

        public BasicSelectDropdownPage(IWebDriver driver) : base(driver)
        {

        }

        private List<int> GetListOfUniqueThreeElements(int options)
        {
            Random random = new Random();
            var listOfElements = new List<int>();
            var previosValue = 0;
            var counter = 3;
           
            while(counter > 0)
            {
                int nextValue = random.Next(START_POSITION, options - 1);

                if (previosValue != nextValue)
                {
                    counter -= 1;
                    previosValue = nextValue;
                    listOfElements.Add(nextValue);
                }
            }

            return listOfElements;
        }

        public IList<IWebElement> ChooseThreeRandomOptions()
        {
            var selectElement = WaitingForElement(selectOptions);
            SelectElement select = new SelectElement(selectElement);
            var options = select.Options;
            var listOfElements = GetListOfUniqueThreeElements(options.Count);

            foreach(var index in listOfElements)
            {
                options[index].Click();
            }

            return select.AllSelectedOptions;
        }
    }
}
