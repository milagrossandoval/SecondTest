using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Test.Test.page;
using Test.Test.page.entidades;

namespace Test
{
    public class StepImplementation
    {
        private IWebDriver driver = null;
        private CreateAccountPage createAccountPage;


        [Step("Navigate to <url>")]
        public void NavigateTo(string url)
        {
            driver = new ChromeDriver();
            createAccountPage = new CreateAccountPage("chrome", url, false);
        }

        [Step("Sign up a new user")]
        public void Register()
        {
            GenerateRandom generateRandom = new GenerateRandom();
            Account account = new Account();
            account.Email = generateRandom.RandomEmail();
            account.FirstName = generateRandom.RandomName();
            account.LastName = "Sandoval";
            account.Password = generateRandom.RandomPassword();
            account.Address = generateRandom.RandomString(6, false);
            account.CodigoPostal = "00000";
            account.Alias = "Ninguna";
            account.Country = "United States";
            account.State = generateRandom.RandomState();
            account.City = "Lima";
            account.Phone = generateRandom.RandomPhone(9);

            var result = createAccountPage.Create(account);
            String name = result.Item1;
            String expectedURL = "?controller=my-account";
            String obtainURL = result.Item2;
            Assert.AreEqual(account.FirstName + " " + account.LastName, name);
            Assert.IsTrue(obtainURL.Contains(expectedURL));
            Assert.IsTrue(result.Item3);
        }   
    }
}
