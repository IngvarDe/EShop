using Newtonsoft.Json;
using System.Collections.Generic;


namespace EShop.Core.Dtos
{
    public class ResultDto
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

    public class CoordDto
    {
        [JsonProperty ("lon")]
        public double Lon { get; set; }
        [JsonProperty ("lat")]
        public double Lat { get; set; }
    }

    public class WeatherDto
    {
        [JsonProperty ("id")]
        public int Id { get; set; }
        [JsonProperty ("main")]
        public string Main { get; set; }
        [JsonProperty ("description")]
        public string Description { get; set; }
        [JsonProperty ("icon")]
        public string Icon { get; set; }
    }

    public class MainDto
    {
        [JsonProperty ("temp")]
        public double Temp { get; set; }
        [JsonProperty ("feels_like")]
        public double Feels_Like { get; set; }
        [JsonProperty ("temp_min")]
        public int TempMin { get; set; }
        [JsonProperty ("temp_max")]
        public double TempMax { get; set; }
        [JsonProperty("pressure")]
        public int Pressure { get; set; }
        [JsonProperty ("humidity")]
        public int Humidity { get; set; }
    }

    public class WindDto
    {
        [JsonProperty ("speed")]
        public double Speed { get; set; }
        [JsonProperty ("deg")]
        public int Deg { get; set; }
    }

    public class CloudsDto
    {
        [JsonProperty ("all")]
        public int All { get; set; }
    }

    public class SysDto
    {
        [JsonProperty ("type")]
        public int Type { get; set; }
        [JsonProperty ("id")]
        public int Id { get; set; }
        [JsonProperty ("country")]
        public string Country { get; set; }
        [JsonProperty ("sunrise")]
        public int Sunrise { get; set; }
        [JsonProperty ("sunset")]
        public int Sunset { get; set; }
    }

    public class WeatherForecastDto
    {
        public CoordDto Coord { get; set; }
        public List<WeatherDto> Weather { get; set; }
        public string @base { get; set; }
        public MainDto Main { get; set; }
        public int Visibility { get; set; }
        public WindDto Wind { get; set; }
        public CloudsDto Clouds { get; set; }
        public int Dt { get; set; }
        public SysDto Sys { get; set; }
        public int TimeZone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }
}
