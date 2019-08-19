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
        private string urlInicial = "http://automationpractice.com/index.php?";
        private CreateAccountPage createAccountPage;


        [Step("Navigate to <url>")]
        public void NavigateTo(string url)
        {
            driver = new ChromeDriver();
            createAccountPage = new CreateAccountPage("chrome", urlInicial, false);
        }



        [Step("Sign up a new user")]
        public void Register()
        {
            Account cuenta = new Account();
            cuenta.Email = "msandoval24" +
                "@cignium.com";
            cuenta.FirstName = "Tatiana";
            cuenta.LastName = "Sandoval";
            cuenta.Password = "abcdABCD1234";
            cuenta.Address = "Arbol #3";
            cuenta.CodigoPostal = "00000";
            cuenta.Alias = "Ninguna";
            cuenta.Country = "United States";
            cuenta.State = "Alaska";
            cuenta.City = "Lima";
            cuenta.Phone = "15184851";

            var resultado = createAccountPage.Crear(cuenta);
            String nombre = resultado.Item1;
            String urlEsperada = "?controller=my-account";
            String urlObtenida = resultado.Item2;
            Assert.AreEqual(cuenta.FirstName + " " + cuenta.LastName, nombre);
            Assert.IsTrue(urlObtenida.Contains(urlEsperada));
            Assert.IsTrue(resultado.Item3);
        }   


    }
}
