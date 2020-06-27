using System;
using System.Linq;
using System.Threading.Tasks;
using EShop.Admin.Models.Commander;
using EShop.Core.Dtos;
using EShop.Core.ServiceInterface;
using EShop.Data;
using Microsoft.AspNetCore.Mvc;


namespace EShop.Admin.Controllers
{
    //[Route("commander")]
    public class CommanderController : Controller
    {
        private readonly ICommanderService _commander;
        private readonly EShopDbContext _context;

        public CommanderController(
            ICommanderService commander,
            EShopDbContext context
            )
        {
            _commander = commander;
            _context = context;
        }

        //Grid
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
        public async Task<IActionResult> Edit(Guid id)
        {
            var command = await _commander.GetAsyncId(id);

            if (command == null)
            {
                return NotFound();
            }

            var model = new CommandViewModel()
            {
                Id = command.Id,
                HowTo = command.HowTo,
                Line = command.Line,
                Platfrom = command.Platfrom
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CommandViewModel model)
        {
            var dto = new CommanderDto()
            {
                Id = model.Id,
                HowTo = model.HowTo,
                Line = model.Line,
                Platfrom = model.Platfrom
            };

            var result = await _commander.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("index", model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            CommandViewModel model = new CommandViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CommandViewModel model)
        {
            var dto = new CommanderDto
            {
                Id = model.Id,
                HowTo = model.HowTo,
                Line = model.Line,
                Platfrom = model.Platfrom
            };

            var result = await _commander.Add(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var commander = await _commander.Delete(id);

            return RedirectToAction("index", commander);
        }
    }
}