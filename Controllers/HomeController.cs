using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CitySearch(string cityName)
        {
            var result = Weather.GetWeather("http://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&appid=" + EnvironmentVariables.ApiKey);
            return Json(result);
        }
    }
}
