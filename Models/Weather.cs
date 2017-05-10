using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace WeatherApp.Models
{
    public class Weather
    {

        [Key]
        public string CityName { get; set; }
        public int ApiId { get; set; }
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public static JObject GetWeather(string cityString)
        {
            var client = new RestClient("http://api.openweathermap.org/data/2.5/weather?q=");
            var request = new RestRequest(cityString, Method.GET);
            request.AddHeader("X-Mashape-Key", EnvironmentVariables.ApiKey);
            request.AddHeader("Accept", "application/json");

            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject result = JsonConvert.DeserializeObject<JObject>(response.Content);
            Console.WriteLine(result);
            return result;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient client, RestRequest request)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            client.ExecuteAsync(request, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}