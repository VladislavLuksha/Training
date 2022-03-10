﻿using AutomationPracticeTests.BusinessObjects.PageObjects.Componets;
using AutomationPracticeTests.CustomComponents;
using AutomationPracticeTests.Entities;
using AutomationPracticeTests.PageObjects.BasePages;
using OpenQA.Selenium;

namespace AutomationPracticeTests.PageObjects.Pages
{
    public class AccountCreationPage : BasePage
    {
        private static readonly By MyAccountLbl = By.ClassName("page-heading");

        public AccountCreationPage() : base(MyAccountLbl, "Create an account") { }

        public Inputs InputFirstName => new Inputs("customer_firstname");

        public Inputs InputLastName => new Inputs("customer_lastname");

        public Inputs InputPassword => new Inputs("passwd");

        public Inputs InputCity => new Inputs("city");

        public Inputs InputAddress => new Inputs("address1");

        public Select SelectCountry => new Select("id_country");

        public Select SelectState => new Select("id_state");

        public Inputs InputPostalCode => new Inputs("postcode");

        public Inputs InputHomePhone => new Inputs("phone");

        public Buttons RegisterButton => new Buttons("submitAccount");

        public AlertMessage AlertMessage => new AlertMessage();

        public void FillRequiredFields(User user)
        {
            InputFirstName.TypeText(user.FirstName);
            InputLastName.TypeText(user.LastName);
            InputPassword.TypeText(user.Password);
            InputAddress.TypeText(user.Address);
            InputCity.TypeText(user.City);
            SelectCountry.SelectElementByText(user.Country);
            SelectState.SelectElementByText(user.State);
            InputPostalCode.TypeText(user.PostalCode);
            InputHomePhone.TypeText(user.HomePhone);
        }

        public MyAccountPage ClickRegisterButton()
        {
            RegisterButton.Click();

            return new MyAccountPage();
        }
    }
}
