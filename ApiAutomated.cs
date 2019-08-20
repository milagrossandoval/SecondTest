using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;
using RestSharp;
using Test.Test.page.entidades;

namespace Test
{
    public class ApiAutomated
    {
        [Step("Get country <code>")]
        public void GetEachCountry(string code)
        {
            var client = new RestClient();
            var request = new RestRequest("https://restcountries.eu/rest/v2/alpha/{code}", Method.GET);
            request.AddUrlSegment("code", code);
            client.Execute(request);
        }


        [Step("Add country")]
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
                

            client.Execute(request);

        }
    }
}
