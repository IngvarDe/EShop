using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Admin.Models.OpenWeatherMapModels
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
        public string Temp{ get; set; }  
        public string TempMax { get; set; }  
        public string TempMin { get; set; }  
        public string WeatherIcon { get; set; }  
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
}
