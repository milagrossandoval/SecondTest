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
    public class StepImplementation
    {
        private IWebDriver driver = null;
        private CreateAccount createAccount;
        private Account account = new Account();
        string expectedURL = "?controller=my-account1";
        string name;        
        string obtainURL;
        bool boolLogOut;

        [Step("Navigate to <url>")]
        public void NavigateTo(string url)
        {
            driver = new ChromeDriver();
            createAccount = new CreateAccount("chrome", url, false);
        }

        [Step("Create a new account")]
        public void RegisterAccount()
        {
            createAccount.SignIn();
            GenerateRandom generateRandom = new GenerateRandom();           
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
            var result = createAccount.Create(account);
            name = result.Item1;
            obtainURL = result.Item2;
            boolLogOut = result.Item3;
            
        }

        [Step("Just registered")]
        public void ValidateAccountCreated()
        {
            Assert.AreEqual(account.FirstName + " " + account.LastName, name);
            Assert.IsTrue(obtainURL.Contains(expectedURL));
            Assert.IsTrue(boolLogOut);

        }
    }
}
