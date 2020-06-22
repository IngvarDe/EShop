using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Admin.Models.Commander;
using EShop.Core.Domain;
using EShop.Core.ServiceInterface;
using EShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Admin.Controllers
{
    public class CommandsController : Controller
    {

        private readonly ICommander _commander;
        private readonly EShopDbContext _context;

        public CommandsController(
            ICommander commander,
            EShopDbContext context
            )
        {
            _commander = commander;
            _context = context;
        }

        public IActionResult Index()
        {
            var seed = _context.Command
                .Select(x => new CommandGridListItem
                {
                    Id = x.Id,
                    HowTo = x.HowTo,
                    Line = x.Line,
                    Platfrom = x.Platfrom
                });

            return View(seed);
        }

        [HttpGet]
        public IEnumerable<Command> GetAllCommands()
        {
            //var commandItems = _commander.GetAppCommands();

            //if (commandItems == null)
            //{
            //    return NotFound();
            //}

            return null;
        }

        [HttpGet]
        public async Task<Command> GetCommandById(Guid id)
        {
            return null;
        }
    }
}