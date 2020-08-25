using EShop.Core.Dtos;
using EShop.Core.Dtos.WeatherForecast;
using EShop.Core.ServiceInterface;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using static EShop.Core.Dtos.WeatherForecastDto;

namespace EShop.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastService
    {

        //with ajax
        public string WeatherDetail(string city)
        {
            string appId = "10802a322cab84354d59fb3e37ee800e";

            string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&cnt=1&APPID={appId}";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                WeatherForecastDto weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherForecastDto>(json);

                ResultDto result = new ResultDto();

                result.Country = weatherInfo.Sys.Country;
                result.City = weatherInfo.Name;
                result.Lat = weatherInfo.Coord.Lat.ToString();
                result.Lon = weatherInfo.Coord.Lon.ToString();
                result.Description = weatherInfo.Weather[0].Description;
                result.Humidity = weatherInfo.Main.Humidity.ToString();
                result.Temp = weatherInfo.Main.Temp.ToString();
                result.TempFeelsLike = weatherInfo.Main.Feels_Like.ToString();
                result.TempMax = weatherInfo.Main.TempMax.ToString();
                result.TempMin = weatherInfo.Main.TempMin.ToString();
                result.WeatherIcon = weatherInfo.Weather[0].Icon;

                var jsonString = new JavaScriptSerializer().Serialize(result);

                return jsonString;
            }
        }

        //no ajax
        WeatherResponseDto IWeatherForecastService.GetForecast(string city)
        {
            string IDOWeather = "10802a322cab84354d59fb3e37ee800e";
            // Connection String
            var client = new RestClient($"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&APPID={IDOWeather}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                // Deserialize the string content into JToken object
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);

                // Deserialize the JToken object into our WeatherResponse Class
                return content.ToObject<WeatherResponseDto>();
            }

            return null;
        }
    }
}
