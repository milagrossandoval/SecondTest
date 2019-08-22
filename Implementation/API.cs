using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;
using NUnit.Framework;
using RestSharp;
using Test.Test.Entities;

namespace Test
{
    public class ApiAutomated
    {
        private IRestResponse response;

        [Step("Get country for <code>")]
        public void GetCountry(string code)
        {
            var client = new RestClient();
            var request = new RestRequest("https://restcountries.eu/rest/v2/alpha/{code}", Method.GET);
            request.AddUrlSegment("code", code);
            response = client.Execute(request);
            Console.WriteLine(response.StatusCode.ToString().Trim());
            Console.WriteLine(response.Content);
        }

        [Step("Validate get country")]
        public void ValidateGetCountry()
        {
            Assert.That(response.StatusCode.ToString().Trim(), Is.Not.EqualTo("NotFound"));

        }
                              
        [Step("Add country <table>")]
        public void AddCountry(Table table)
        {
            var tableRows = table.GetTableRows();
            var client = new RestClient();
            var request = new RestRequest("https://restcountries.eu/rest/v2/alpha/add",Method.POST);

            foreach (var row in tableRows)
            {
                request.AddJsonBody(new Country {
                name = row.GetCell("name"),
                alpha2_code = row.GetCell("alpha2_code"),
                alpha3_code = row.GetCell("alpha3_code")
                });
            }
            response = client.Execute(request);
        }

        [Step("Validate add country")]
        public void ValidateAddCountry()
        {
            Assert.That(response.StatusCode.ToString().Trim(), Is.EqualTo("NotFound"));
        }
    }
}
