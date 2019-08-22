using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;
using NUnit.Framework;
using RestSharp;
using Test.Test.page.entidades;

namespace Test
{
    public class ApiAutomated
    {
        [Step("Get country for <code>")]
        public void GetEachCountry(string code)
        {
            var client = new RestClient();
            var request = new RestRequest("https://restcountries.eu/rest/v2/alpha/{code}", Method.GET);
            request.AddUrlSegment("code", code);
            var response = client.Execute(request);
            Console.WriteLine(response.StatusCode.ToString().Trim());
            Console.WriteLine(response.Content);
            Assert.That(response.StatusCode.ToString().Trim(), Is.Not.EqualTo("NotFound"));
        }


        [Step("Add country <table>")]
        public void Add(Table table)
        {
            var tableRows = table.GetTableRows();
            var client = new RestClient();
            var request = new RestRequest("https://restcountries.eu/rest/v2/alpha/add",Method.POST);

            foreach (var row in tableRows)
            {
                request.AddJsonBody(new TestObject {
                name = row.GetCell("name"),
                alpha2_code = row.GetCell("alpha2_code"),
                alpha3_code = row.GetCell("alpha3_code")
                });
            }
            Assert.That(request,Is.Not.Null);

            client.Execute(request);

        }
    }
}
