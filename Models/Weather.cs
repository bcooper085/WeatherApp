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
        public static string City { get; set; }
        public Weather(string CityName) {
            City = CityName;
        }

        public List<Weather> GetWeather()
        {
            
            var apiKey = "fa04998c118d8986d05549418958fabf";
            var request = new RestRequest("http://api.openweathermap.org/data/2.5/weather?q=" + Weather.City + "&appid=" + apiKey, Method.GET);
            
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var weatherList = JsonConvert.DeserializeObject<List<Weather>>(jsonResponse["name"].ToString());
            return weatherList;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestRequest theRequest)
        {
            var client = new RestClient();
            var tcs = new TaskCompletionSource<IRestResponse>();
            client.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}