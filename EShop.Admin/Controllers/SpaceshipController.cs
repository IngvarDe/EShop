using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Admin.Models.Spaceship;
using EShop.Core.Domain;
using EShop.Core.Dtos;
using EShop.Core.ServiceInterface;
using EShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShop.Admin.Controllers
{
    public class SpaceshipController : Controller
    {
        private readonly EShopDbContext _context;
        private readonly ISpaceshipService _spaceshipService;

        public SpaceshipController(
            EShopDbContext context,
            ISpaceshipService spaceshipService
            )
        {
            _context = context;
            _spaceshipService = spaceshipService;
        }

        //Grid
        [HttpGet]
        public IActionResult Index()
        {
            var seed = _context.Spaceship
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new SpaceshipGridListItem
                {
                    Id = x.Id,
                    CrewSize = x.CrewSize,
                    Armament = x.Armament,
                    Role = x.Role
                });

            return View(seed);
        }

        [HttpGet]
        public IActionResult Add()
        {
            SpaceshipViewModel model = new SpaceshipViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SpaceshipViewModel model)
        {
            var dto = new SpaceshipDto
            {
                Id = model.Id,
                CrewSize = model.CrewSize,
                Armament = model.Armament,
                Role = model.Role,
                CreatedAt = model.CreatedAt,
                ModifiedAt = model.ModifiedAt,
                Files = model.Files,
                Image = model.Image.Select(x => new FileToDatabaseDto
                {
                    Id = x.ImageId,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    SpaceshipId = x.SpaceshipId
                }).ToArray()
            };

            var result = await _spaceshipService.Add(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("index", model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var spaceship = await _spaceshipService.GetAsync(id);

            if (spaceship == null)
            {
                return NotFound();
            }

            var photos = await _context.FileToDatabase
                .Where(x => x.SpaceshipId == id)
                .Select(m => new ImagesViewModel
                {
                    ImageData = m.ImageData,
                    ImageId = m.Id,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(m.ImageData)),
                    ImageTitle = m.ImageTitle,
                    SpaceshipId = m.Id
                })
                .ToArrayAsync();

            var model = new SpaceshipViewModel();

            model.Id = spaceship.Id;
            model.CrewSize = spaceship.CrewSize;
            model.Armament = spaceship.Armament;
            model.Role = spaceship.Role;
            model.CreatedAt = spaceship.CreatedAt;
            model.ModifiedAt = spaceship.ModifiedAt;
            model.Image.AddRange(photos);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SpaceshipViewModel model)
        {
            var dto = new SpaceshipDto()
            {
                Id = model.Id,
                CrewSize = model.CrewSize,
                Armament = model.Armament,
                Role = model.Role,
                CreatedAt = model.CreatedAt,
                ModifiedAt = model.ModifiedAt,
                Files = model.Files,
                Image = model.Image.Select(x => new FileToDatabaseDto
                {
                    Id = x.ImageId,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    SpaceshipId = x.SpaceshipId
                })
            };

            var result = await _spaceshipService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var sapceship = await _spaceshipService.Delete(id);
            if (sapceship == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), sapceship);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(ImagesViewModel file)
        {
            var dto = new FileToDatabaseDto()
            {
                Id = file.ImageId,
            };

            var image = await _spaceshipService.RemoveImage(dto);
            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}