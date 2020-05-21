using Microsoft.AspNetCore.Mvc;


namespace EShop.Admin.Controllers
{
    public class UsersController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}