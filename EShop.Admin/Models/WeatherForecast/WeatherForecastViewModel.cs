using System.Collections.Generic;


namespace EShop.Admin.Models.WeatherForecast
{
    public class ResultViewModel
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Description { get; set; }
        public string Humidity { get; set; }
        public string TempFeelsLike { get; set; }
        public string Temp { get; set; }
        public string TempMax { get; set; }
        public string TempMin { get; set; }
        public string WeatherIcon { get; set; }
    }

    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public int temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class RootObject
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }

    //public class WeatherForecastViewModel
    //{
    //    public string City { get; set; }
    //    public string Country { get; set; }
    //    public string Lat { get; set; }
    //    public string Lon { get; set; }
    //    public string Description { get; set; }
    //    public string Humidity { get; set; }
    //    public string TempFeelsLike { get; set; }
    //    public string Temp { get; set; }
    //    public string TempMax { get; set; }
    //    public string TempMin { get; set; }
    //    public string WeatherIcon { get; set; }
    //}

    //public class CoordDto
    //{
    //    public double Lon { get; set; }
    //    public double Lat { get; set; }
    //}

    //public class WeatherDto
    //{
    //    public int Id { get; set; }
    //    public string Main { get; set; }
    //    public string Description { get; set; }
    //    public string Icon { get; set; }
    //}

    //public class MainDto
    //{
    //    public double Temp { get; set; }
    //    public double Feels_Like { get; set; }
    //    public int TempMin { get; set; }
    //    public double TempMax { get; set; }
    //    public int Pressure { get; set; }
    //    public int Humidity { get; set; }
    //}

    //public class WindDto
    //{
    //    public double Speed { get; set; }
    //    public int Deg { get; set; }
    //}

    //public class CloudsDto
    //{
    //    public int All { get; set; }
    //}

    //public class SysDto
    //{
    //    public int Type { get; set; }
    //    public int Id { get; set; }
    //    public string Country { get; set; }
    //    public int Sunrise { get; set; }
    //    public int Sunset { get; set; }
    //}

    //public class RootObject
    //{
    //    public CoordDto Coord { get; set; }
    //    public List<WeatherDto> Weather { get; set; }
    //    public string @base { get; set; }
    //    public MainDto Main { get; set; }
    //    public int Visibility { get; set; }
    //    public WindDto Wind { get; set; }
    //    public CloudsDto Clouds { get; set; }
    //    public int Dt { get; set; }
    //    public SysDto Sys { get; set; }
    //    public int TimeZone { get; set; }
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public int Cod { get; set; }
    //}
}
