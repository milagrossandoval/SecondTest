using System;
using Gauge.CSharp.Lib.Attribute;
using NUnit.Framework;
using Entities;
using Pages;
using Util;

namespace Implementation
{
    public class CreateAccount
    {
        private readonly CreateAccountPage createAccount = new CreateAccountPage();
        private Account account;


        [BeforeSuite]
        public void BeforeSuite()
        {
            string browser = Environment.GetEnvironmentVariable("browser");
            createAccount.InitializeDriver(browser);
        }

        [Step("Navigate to <url>")]
        public void NavigateTo(string url)
        {
            url = Environment.GetEnvironmentVariable("urlAutomation");
            createAccount.NavigateTo(url);
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
            //var nombre = $"{account.FirstName} {account.LastName}";
            //string test = $"hi";
            Assert.AreEqual(account.FirstName + " " + account.LastName, createAccount.GetHeaderdAccount());
            //Assert.AreEqual(nombre, createAccount.GetHeaderdAccount());

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
