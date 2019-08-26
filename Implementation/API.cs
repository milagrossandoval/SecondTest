using System;
using System.Collections.Generic;
using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;
using RestSharp;
using Entities;
using System.Net;
using FluentAssertions;

namespace Implementation
{
    public class API
    {
        private IRestResponse response;

        [Step("Get country for <code>")]
        public void GetCountry(string code)
        {
            var client = new RestClient();
            var request = new RestRequest(Environment.GetEnvironmentVariable("urlGetCountry"), Method.GET);
            request.AddUrlSegment("code", code);
            response = client.Execute(request);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
        }

        [Step("Validate get country")]
        public void ValidateGetCountry()
        {
            var obtainResponse = response.StatusCode;
            obtainResponse.Should().Be(HttpStatusCode.OK);
        }

        [Step("Add country <table>")]
        public void AddCountry(Table table)
        {
            List<TableRow> tableRows = table.GetTableRows();
            var client = new RestClient();
            var request = new RestRequest(Environment.GetEnvironmentVariable("urlAddCountry"),Method.POST);

            foreach (TableRow row in tableRows)
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
            var obtainResponse = response.StatusCode;
            obtainResponse.Should().Be(HttpStatusCode.MethodNotAllowed);
        }
    }
}
