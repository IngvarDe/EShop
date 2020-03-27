using System;
using System.Linq;
using System.Threading.Tasks;
using EShop.Admin.Models.Product;
using EShop.Common.Extensions;
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


        [HttpGet]
        public IActionResult Index()
        {

            var seed = _context.Product
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
        public IActionResult Edit()
        {
            ProductViewModel model = new ProductViewModel();

            if (!ModelState.IsValid)
            {
                return ValidationError();
            }

            var dto = new ProductDto()
            {
                Id = model.Id,
                Description = model.Description,
                Name = model.Name,
                Value = model.Value
            };

            var result = _productService.Save(dto);
            if (!result.IsSuccess)
            {
                Response.StatusCode = ApplicationHttpStatusCodes.ValidationError;
                return Json(ModelState.Errors());
            }

            return RedirectToAction("Edit", model);
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