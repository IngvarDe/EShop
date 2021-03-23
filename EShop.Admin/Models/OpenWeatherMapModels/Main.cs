using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Admin.Models.OpenWeatherMapModels
{
    public class Main
    {
        public float temp { get; set; }
        public int Pressure { get; set; }
        public int humidity { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
        public double feels_like { get; set; }
    }
}
