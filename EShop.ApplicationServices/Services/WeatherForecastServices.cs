using EShop.Core.ServiceInterface;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using static EShop.Core.Dtos.WeatherForecastDto;

namespace EShop.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastService
    {
        public string WeatherDetail(string City)
        {
            string appId = "8113fcc5a7494b0518bd91ef3acc074f";

            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&cnt=1&APPID={1}", City, appId);

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                RootObject weatherInfo = (new JavaScriptSerializer()).Deserialize<RootObject>(json);

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
    }
}
