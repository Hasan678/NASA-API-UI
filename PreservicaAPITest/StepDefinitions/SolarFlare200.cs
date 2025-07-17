using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using System.Text.Json;
using PreservicaAPITest.DeserializedJson;

namespace PreservicaAPITest.StepDefinitions
{
    [Binding]
    public class SolarFlare200
    {
        private RestResponse _response = new RestResponse();

        [When("I send a request to the FLR API")]
        public void FlrApiRequest()
        {
            var url = "https://api.nasa.gov";

            var client = new RestClient(url);
            var request = new RestRequest("DONKI/FLR", Method.Get);

            request.AddParameter("api_key", "WHJfm31QbHCFFxh939nCjgonTbxxyg9TW2FsybS6");

            _response = client.Execute<RestResponse>(request);

            var response = client.Execute(request);

            var flares = JsonSerializer.Deserialize<List<CMEJSON>>(_response.Content);
            var limitedFlares = flares?.Take(2).ToList();

            Console.WriteLine("Request URL: " + client.BuildUri(request));
            Console.WriteLine("STATUS CODE: " + _response.StatusCode );
            Console.WriteLine("ERROR: " + _response.ErrorMessage);
            Console.WriteLine("CONTENT: " + _response.Content);
        }

        [Then("The FLR API response should be 200")]
        public void FlrApiResponse()
        {
            Assert.IsNotNull(_response, "This shows nothing, it might have failed!");

            var statusCode = (int)_response.StatusCode;
            
            Console.WriteLine("Assert status code: " + statusCode);

            Assert.AreEqual(200, statusCode, "Expected status code 200 but got " + statusCode);
        }

        //Moving onto the dates testing from here..
        [When(@"I send a date range request to the FLR API with start date ""(.*)"" and end date ""(.*)""")]
        public void FlrApiDatesRequest(string startDate, string endDate)
        {
            var url = "https://api.nasa.gov";
            var client = new RestClient(url);
            var request = new RestRequest("DONKI/FLR");

            request.AddParameter("startDate", startDate);
            request.AddParameter("endDate", endDate);
            request.AddParameter("api_key", "WHJfm31QbHCFFxh939nCjgonTbxxyg9TW2FsybS6");

            _response = client.Execute(request);

            var flares = JsonSerializer.Deserialize<List<CMEJSON>>(_response.Content);
            var limitedFlares = flares?.Take(2).ToList();

            Console.WriteLine("Request URL: " + client.BuildUri(request));
            Console.WriteLine("STATUS CODE: " + _response.StatusCode);
            Console.WriteLine("ERROR: " + _response.ErrorMessage);
            Console.WriteLine("CONTENT: " + _response.Content);

        }

        [Then("The FLR API should return dates with response status 200")]
        public void FlrApiDatesResponse()
        {
            Assert.IsNotNull(_response, "This shows nothing, it might have failed!");
            Assert.IsFalse(string.IsNullOrWhiteSpace(_response.Content));

            var statusCode = (int)_response.StatusCode;
            Console.WriteLine("Assert status code: " + statusCode);
            Assert.AreEqual(200, statusCode, "Expected status code 200 but got " + statusCode);
        }


        [When(@"I send an incorrect API call to the fLR API")]
        public void FlrApiNegativeTest()
        {
            var url = "https://api.nasa.gov";
            var client = new RestClient(url);
            var request = new RestRequest("DONKI/FLR", Method.Get);

            request.AddQueryParameter("api_key", "HJfm31QbHCFFxh939nCjgonTbxxyg9TW2FsybS6");

            _response = client.Execute(request);
            var flares = JsonSerializer.Deserialize<List<CMEJSON>>(_response.Content);
            var limitedFlares = flares?.Take(2).ToList();


            //Just for my workings out.
            Console.WriteLine("Request URL: " + client.BuildUri(request));
            Console.WriteLine("STATUS CODE: " + _response.StatusCode);
            Console.WriteLine("ERROR: " + _response.ErrorMessage);
            Console.WriteLine("CONTENT: " + _response.Content);
        }

        [Then("The FLR API response should give me a 403 code")]
        public void FlrApiNegativeResponse()
        {
            Assert.IsNotNull(_response, "This Request has FAILED!!");

            var statusCode = (int)_response.StatusCode;
            Console.WriteLine("Assert status code: " + statusCode);
            Assert.AreEqual(403, statusCode, "Expecting a 403 here -> " + statusCode);
        }
    }
}
