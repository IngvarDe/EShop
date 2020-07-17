using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using static EShop.Core.Dtos.WeatherForecastDto;

namespace EShop.ApplicationServices.Services
{
    public class WeatherForecastServices
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
                //result Lat

                return json;
            }



        }
    }
}
