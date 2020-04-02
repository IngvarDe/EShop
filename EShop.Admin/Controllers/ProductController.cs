using System;
using System.Linq;
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
            int queueNumber = 0;
            queueNumber++;

            var seed = _context.Product
                .Select(x => new ProductGridListItem
                {
                    Id = x.Id,
                    QueueNumber = queueNumber,
                    Name = x.Name,
                    Description = x.Description,
                    Value = x.Value
                });

            return View(seed);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            ProductDto model = new ProductDto();

            if (!ModelState.IsValid)
            {
                return ValidationError();
            }

            var vm = new ProductDto()
            {
                Id = id,
                Description = model.Description,
                Name = model.Name,
                Value = model.Value
            };

            var result = _productService.Edit(vm);

            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel model)
        {
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
    }
}