using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Test.Test.Entities;
using Test.Test.Model;
using Test.Test.Util;

namespace Test
{
    public class CreateAccount
    {
        private CreateAccountPage createAccount;
        private Account account;


        [BeforeScenario]
        public void BeforeScenario(string url)
        {
           
        }


        [Step("Navigate to <url>")]
        public void NavigateTo(string url)
        {
            createAccount = new CreateAccountPage("chrome", url);
        }

        [Step("Create a new account")]
        public void RegisterAccount()
        {
            createAccount.SignIn();
            GenerateRandom generateRandom = new GenerateRandom();
            account = new Account();
            account.Email = GenerateRandom.RandomEmail();
            account.FirstName = GenerateRandom.RandomName();
            account.LastName = GenerateRandom.RandomLastName();
            account.Password = GenerateRandom.RandomPassword();
            account.Address = GenerateRandom.RandomString(6, false);
            account.PostalCode = "00000";
            account.Alias = "Ninguna";
            account.Country = "United States";
            account.State = GenerateRandom.RandomState();
            account.City = "Lima";
            account.Phone = GenerateRandom.RandomPhone(9);
            createAccount.CreateAccount(account);
        }

        [Step("Validate registered account")]
        public void ValidateAccountCreated()
        {
            //string nombre = $"{account.FirstName} {account.LastName}";
            //string nombre = string.Format("{account.FirstName} {account.LastName}");
            //string nombre = $"{account.FirstName} {account.LastName}";

            Assert.AreEqual(account.FirstName + " " + account.LastName, createAccount.GetHeaderdAccount());

        }

        [Step("Validate expected url")]
        public void ValidateExpectedURL()
        {
            string expectedURL = "?controller=my-account";
            Assert.IsTrue(createAccount.GetURL().Contains(expectedURL));
        }

        [Step("Validate button logout")]
        public void ValidateButtonLogout()
        {
            Assert.IsTrue(createAccount.GetDisplayButtonLogout());
        }

        [Step("Close driver")]
        public void AfterScenario()
        {
            createAccount.ClosePage();
        }
    }
}
