using NUnit.Framework;
using RestSharp;
using System.Text.Json;
using TechTalk.SpecFlow;

namespace PreservicaAPITest.StepDefinitions
{
    [Binding]
    public class CoronalMassEjection200
    {
        private RestResponse _response;

        [When("I send a request to the CME API")]
            public void CmeApiRequest()
            {
                var url = "https://api.nasa.gov";

                var client = new RestClient(url);
                var request = new RestRequest("DONKI/CME", Method.Get);

                request.AddParameter("api_key", "WHJfm31QbHCFFxh939nCjgonTbxxyg9TW2FsybS6");

                _response = client.Execute(request);

                var flares = JsonSerializer.Deserialize<List<FlareEvent>>(_response.Content);
                var limitedFlares = flares?.Take(2).ToList();

                Console.WriteLine("Request URL: " + client.BuildUri(request));
                Console.WriteLine("STATUS CODE: " + _response.StatusCode);
                Console.WriteLine("ERROR: " + _response.ErrorMessage);
                Console.WriteLine("CONTENT: " + _response.Content);
            }

        [Then("The CME API response status should be 200")]
        public void CmeApiResponse() 
        {
            Assert.IsNotNull(_response, "This shows nothing, it might have failed!");

            var statusCode = (int)_response.StatusCode;
            Console.WriteLine("Assert status code: " + statusCode);

            Assert.AreEqual(200, statusCode, "Expected status code 200 but got " + statusCode);
        }

        [When(@"I send a date range request to the CME API with startDate ""(.*)"" and endDate ""(.*)""")]
        public void CmeApiDateRequest(string startDate, string endDate)
        {
            var url = "https://api.nasa.gov";
            var client = new RestClient(url);
            var request = new RestRequest("DONKI/CME");

            request.AddParameter("startDate", startDate);
            request.AddParameter("endDate", endDate);
            request.AddParameter("api_key", "WHJfm31QbHCFFxh939nCjgonTbxxyg9TW2FsybS6");

            _response = client.Execute(request);

            Console.WriteLine("Request URL: " + client.BuildUri(request));
            Console.WriteLine("STATUS CODE: " + _response.StatusCode);
            Console.WriteLine("ERROR: " + _response.ErrorMessage);
            Console.WriteLine("CONTENT: " + _response.Content);
        }

        [Then("The CME API should return dates with response status 200")]
        public void CmeApiDatesResponse()
        {
            Assert.IsNotNull(_response, "This shows nothing, it might have failed!");
            var statusCode = (int)_response.StatusCode;
            Console.WriteLine("Assert status code: " + statusCode);
            Assert.AreEqual(200, statusCode, "Expected status code 200 but got " + statusCode);

        }

        [When("I send an API request with an incorrect api key")]
        public void CmeApiNegativeTest()
        {
            var url = "https://api.nasa.gov";
            var client = new RestClient(url);
            var request = new RestRequest("DONKI/CME", Method.Get);

            request.AddQueryParameter("api_key", "HJfm31QbHCFFxh939nCjgonTbxxyg9TW2FsybS6");

            _response = client.Execute(request);

            Console.WriteLine("Request URL: " + client.BuildUri(request));
            Console.WriteLine("STATUS CODE: " + _response.StatusCode);
            Console.WriteLine("ERROR: " + _response.ErrorMessage);
            Console.WriteLine("CONTENT: " + _response.Content);
        }

        [Then("The CME API response should give me a 403 code")]
        public void CmeApiNegativeResponse()
        {
            Assert.IsNotNull(_response, "This shows nothing, it might have failed!");
            var statusCode = (int)_response.StatusCode;
            Console.WriteLine("Assert status code: " + statusCode);
            Assert.AreEqual(403, statusCode, "Expecting 403 here for wrong API" + statusCode);
        }
    }
}