using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Admin.Controllers
{
    public class WeatherForecastController : Controller
    {
        public IActionResult Weather()
        {
            return View();
        }
    }
}