﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Admin.Models.Commander;
using EShop.Core.ServiceInterface;
using EShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Admin.Controllers
{
    [Route("commander")]
    public class CommanderController : Controller
    {
        private readonly ICommander _commander;
        private readonly EShopDbContext _context;

        public CommanderController(
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

        //[HttpGet]
        //public IEnumerable<Command> GetAllCommands()
        //{
        //var commandItems = _commander.GetAppCommands();

        //if (commandItems == null)
        //{
        //    return NotFound();
        //}

        //return null;
        //}

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
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
    }
}