using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Core.Dtos.WeatherForecast
{
    public class Main
    {
        public float Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public float Temp_Min { get; set; }
        public float Temp_Max { get; set; }
        public double Feels_Like { get; set; }
    }
}
