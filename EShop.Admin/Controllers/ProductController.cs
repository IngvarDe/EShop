using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EShop.Admin.Models.Product;
using EShop.Core.Dtos;
using EShop.Core.ServiceInterface;
using EShop.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Admin.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly EShopDbContext _context;

        public ProductController
            (
            IProductService productService,
            EShopDbContext context
            )
        {
            _productService = productService;
            _context = context;
        }

        //Grid
        [HttpGet]
        public IActionResult Index()
        {
            var seed = _context.Product
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new ProductGridListItem
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Value = x.Value
                });

            return View(seed);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ProductViewModel model = new ProductViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public Task<IActionResult> Add(ProductViewModel model)
        {
            return Save(model, true);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await _productService.GetAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var model = new ProductViewModel
            {
                Id = product.Id,
                Description = product.Description,
                Name = product.Name,
                Value = product.Value,
                CreatedAt = product.CreatedAt,
                ModifiedAt = product.ModifiedAt
            };

            return View(model);
        }

        [HttpPost]
        public Task<IActionResult> Edit(ProductViewModel model)
        {
            return Save(model, false);
        }

        private async Task<IActionResult> Save(ProductViewModel model, bool isNew = false)
        {
            var dto = new ProductDto()
            {
                Id = model.Id,
                Description = model.Description,
                Name = model.Name,
                Value = model.Value,
                ModifiedAt = model.ModifiedAt,
                CreatedAt = model.CreatedAt
            };

            var result = isNew
                ? _productService.Add(dto)
                : _productService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await _productService.Delete(id);
            if (product == null)
            {
                return RedirectToAction(nameof(Edit));
            }

            return RedirectToAction(nameof(Index), product);
        }

        //private async Task SaveFile(ProductFileViewModel model)
        //{
        //    string fileName = Path.GetFileName(model.File.FileName);

        //}

        public async Task<IActionResult> UploadAsync(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.GetTempFileName();

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            return Ok(new { count = files.Count, size });
        }
    }
}