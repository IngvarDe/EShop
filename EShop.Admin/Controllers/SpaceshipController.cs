using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Admin.Models.Spaceship;
using EShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Admin.Controllers
{
    public class SpaceshipController : Controller
    {
        private readonly EShopDbContext _context;

        public SpaceshipController(
            EShopDbContext context
            )
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            //var seed = _context.Spaceship
            //    .OrderByDescending(y => y.CreatedAt)
            //    .Select(x => new SpaceshipGridListItem
            //    {
            //        Id = x.Id,
            //        CrewSize = x.CrewSize,
            //        Armament = x.Armament,
            //        Role = x.Role
            //    });

            return View();
        }
    }
}