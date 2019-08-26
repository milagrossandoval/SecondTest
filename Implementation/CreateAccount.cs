using System;
using Gauge.CSharp.Lib.Attribute;
using Entities;
using Pages;
using Util;
using FluentAssertions;

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
            string nombre = $"{account.FirstName} {account.LastName}";
            nombre.Should().Be(createAccount.GetHeaderdAccount());
        }

        [Step("Validate expected url")]
        public void ValidateExpectedURL()
        {
            string expectedURL = "?controller=my-account";
            string actualURL = createAccount.GetURL();
            actualURL.Should().Contain(expectedURL);
        }

        [Step("Validate button logout")]
        public void ValidateButtonLogout()
        {
            bool DisplayButtonLogout = createAccount.GetDisplayButtonLogout();
            DisplayButtonLogout.Should().BeTrue();
        }

        [Step("Close driver")]
        public void AfterScenario()
        {
            createAccount.ClosePage();
        }
    }
}
