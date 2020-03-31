using System;
using System.Linq;
using System.Threading.Tasks;
using EShop.Admin.Models.Product;
using EShop.Common.Extensions;
using EShop.Common.Helpers;
using EShop.Core.Dtos;
using EShop.Core.ServiceInterface;
using EShop.Data;
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

            //if (isNew == true)
            //{
            //    dto = new ProductDto()
            //    {
            //        Id = model.Id,
            //        Description = model.Description,
            //        Name = model.Name,
            //        Value = model.Value,
            //        ModifiedAt = model.ModifiedAt,
            //        CreatedAt = model.CreatedAt
            //    };
            //}
            //else
            //{
            //    dto = new ProductDto()
            //    {
            //        Id = model.Id,
            //        Description = model.Description,
            //        Name = model.Name,
            //        Value = model.Value,
            //        ModifiedAt = model.ModifiedAt,
            //        CreatedAt = model.CreatedAt
            //    };
            //}

            var result = isNew
                ? _productService.Add(dto)
                : _productService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View("Edit", model);
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
                Value = product.Value
            };

            return View(model);
        }

        [HttpPost]
        public Task<IActionResult> Edit(ProductViewModel model)
        {
            return Save(model, false);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            ProductDto dto = new ProductDto();

            var product = _productService.Delete(dto);
            if (product == null)
            {
                return RedirectToAction(nameof(Edit));
            }

            return RedirectToAction(nameof(Index), id);
        }
    }
}