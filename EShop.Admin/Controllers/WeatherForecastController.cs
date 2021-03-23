using EShop.Admin.Models.Forecast;
using EShop.Admin.Models.OpenWeatherMapModels;
using EShop.Admin.Models.WeatherForecast;
using EShop.Core.Dtos.WeatherForecast;
using EShop.Core.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using System;
using System.Net;

namespace EShop.Admin.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(
            IWeatherForecastService weatherForecastService
            )
        {
            _weatherForecastService = weatherForecastService;
        }

        //without ajax
        [HttpGet]
        public IActionResult SearchCity()
        {
            SearchCity model = new SearchCity();

            return View(model);
        }

        //without ajax
        [HttpPost]
        public IActionResult SearchCity(SearchCity model)
        {
            // If the model is valid, consume the Weather API to bring the data of the city
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "WeatherForecast", new { city = model.CityName });
            }
            return View(model);
        }

        // GET: ForecastApp/City
        //without ajax
        public IActionResult City(string city)
        {
            WeatherResponseDto weatherResponse = _weatherForecastService.GetForecast(city);
            City model = new City();

            if (weatherResponse != null)
            {
                model.Name = weatherResponse.Name;
                model.Humidity = weatherResponse.Main.Humidity;
                model.Pressure = weatherResponse.Main.Pressure;
                model.Temp = weatherResponse.Main.Temp;
                model.Weather = weatherResponse.Weather[0].Main;
                model.Wind = weatherResponse.Wind.Speed;
                model.TempFeelsLike = weatherResponse.Main.Feels_Like;
            }

            return View(model);
        }

        //with ajax
        [HttpGet]
        public IActionResult Weather()
        {
            Models.OpenWeatherMapModels.ResultViewModel model = new Models.OpenWeatherMapModels.ResultViewModel();

            return View("weather", model);
        }

        //with ajax
        [HttpPost]
        public String WeatherDetail(string City)
        {

            string appId = "10802a322cab84354d59fb3e37ee800e";

            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&cnt=1&APPID={1}", City, appId);

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                Models.OpenWeatherMapModels.RootObject weatherInfo = (new JavaScriptSerializer()).Deserialize<Models.OpenWeatherMapModels.RootObject>(json);

                Models.OpenWeatherMapModels.ResultViewModel rslt = new Models.OpenWeatherMapModels.ResultViewModel();

                rslt.Country = weatherInfo.sys.country;
                rslt.City = weatherInfo.name;
                rslt.Lat = Convert.ToString(weatherInfo.coord.lat);
                rslt.Lon = Convert.ToString(weatherInfo.coord.lon);
                rslt.Description = weatherInfo.weather[0].description;
                rslt.Humidity = Convert.ToString(weatherInfo.main.humidity);
                rslt.Temp = Convert.ToString(weatherInfo.main.temp);
                rslt.TempFeelsLike = Convert.ToString(weatherInfo.main.feels_like);
                rslt.TempMax = Convert.ToString(weatherInfo.main.temp_max);
                rslt.TempMin = Convert.ToString(weatherInfo.main.temp_min);
                rslt.WeatherIcon = weatherInfo.weather[0].icon;

                var jsonstring = new JavaScriptSerializer().Serialize(rslt);
 
                return jsonstring;
            }
        }
    }
}