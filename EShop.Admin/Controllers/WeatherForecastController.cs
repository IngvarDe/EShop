using EShop.Admin.Models.WeatherForecast;
using EShop.Core.Dtos;
using EShop.Core.ServiceInterface;
using Microsoft.AspNetCore.Mvc;


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

        [HttpGet]
        public IActionResult Weather()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WeatherDetail(WeatherForecastViewModel model)
        {
            ResultDto dto = new ResultDto();

            var weatherResult = _weatherForecastService.WeatherDetail(dto.City);

            if (weatherResult == null)
            {
                return NotFound();
            }

            model.City = _weatherForecastService.WeatherDetail(dto.City);
            model.Country = dto.Country;
            model.Lat = dto.Lat;
            model.Lon = dto.Lon;
            model.Description = dto.Description;
            model.Humidity = dto.Humidity;
            model.Temp = dto.Temp;
            model.TempFeelsLike = dto.TempFeelsLike;
            model.TempMax = dto.TempMax;
            model.TempMin = dto.TempMin;
            model.WeatherIcon = dto.WeatherIcon;

            //var result = _weatherForecastService.WeatherDetail();

            return View(model);
        }
    }
}