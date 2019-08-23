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

        [Step("Just registered")]
        public void ValidateAccountCreated()
        {
            var result = createAccount.validateCreate();
            string name = result.Item1;
            string obtainURL = result.Item2;
            string expectedURL = "?controller=my-account";
            bool boolLogOut = result.Item3;
            Assert.AreEqual(account.FirstName + " " + account.LastName, name);
            Assert.IsTrue(obtainURL.Contains(expectedURL));
            Assert.IsTrue(boolLogOut);
            createAccount.ClosePage();
        }

        //[AfterScenario]
        //public void AfterScenario()
        //{
        //    createAccount.ClosePage();
        //}
    }
}
