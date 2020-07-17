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