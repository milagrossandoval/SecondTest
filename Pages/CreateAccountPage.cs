﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Entities;
using Util;
using DriverImpl;

namespace Pages
{
    public class CreateAccountPage
    {
        private IWebDriver driver = null;
        private readonly By btnSign = By.LinkText("Sign in");
        private readonly By txtEmail = By.Id("email_create");
        private readonly By btnSubmit = By.Id("SubmitCreate");
        private readonly By txtFirstName = By.Id("customer_firstname");
        private readonly By txtLastName = By.Id("customer_lastname");
        private readonly By txtPass = By.Id("passwd");
        private readonly By txtAddress = By.Id("address1");
        private readonly By txtCity = By.Id("city");
        private readonly By txtPostal = By.Id("postcode");
        private readonly By txtPhone = By.Id("phone_mobile");
        private readonly By txtAlias = By.Id("alias");
        private readonly By btnSubmitAccount = By.Id("submitAccount");
        private readonly By headerName = By.XPath("//*[@id='header']/div[2]/div/div/nav/div[1]/a/span");
        private readonly By btnLogout = By.ClassName("logout");

        public void InitializeDriver(string browser)
        {
            driver = Driver.InitializeDriver(browser);
        }

        public void NavigateTo(string url)
        {
           driver.Navigate().GoToUrl(url);
        }

        public void SignIn()
        {
            driver.FindElement(btnSign).Click();
        }

        public void CreateAccount(Account account)
        {
            driver.FindElement(txtEmail).SendKeys(account.Email);
            driver.FindElement(btnSubmit).Click();
            WaitDriver.WaitForElement(driver,txtFirstName);
            driver.FindElement(txtFirstName).SendKeys(account.FirstName);
            driver.FindElement(txtLastName).SendKeys(account.LastName);
            driver.FindElement(txtPass).SendKeys(account.Password);
            driver.FindElement(txtAddress).SendKeys(account.Address);
            driver.FindElement(txtCity).SendKeys(account.City);
            var cboState = new SelectElement(driver.FindElement(By.Id("id_state")));
            cboState.SelectByText(account.State);
            driver.FindElement(txtPostal).SendKeys(account.PostalCode);
            var cboCountry = new SelectElement(driver.FindElement(By.Id("id_country")));
            cboCountry.SelectByText(account.Country);
            driver.FindElement(txtPhone).SendKeys(account.Phone);
            driver.FindElement(txtAlias).SendKeys(account.Alias);
            driver.FindElement(btnSubmitAccount).Click();
        }

        public string GetHeaderdAccount()
        {
            return driver.FindElement(headerName).Text;
        }

        public string GetURL()
        {
            return driver.Url;
        }

        public bool GetDisplayButtonLogout()
        {
            return driver.FindElement(btnLogout).Displayed;
        }
               
        public void ClosePage()
        {
            Driver.ClosePage(driver);
        }

    }
}
