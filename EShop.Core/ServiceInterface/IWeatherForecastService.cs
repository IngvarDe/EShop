using EShop.Core.Dtos.WeatherForecast;

namespace EShop.Core.ServiceInterface
{
    public interface IWeatherForecastService
    {
        string WeatherDetail(string City);

        WeatherResponseDto GetForecast(string city);
    }
}
