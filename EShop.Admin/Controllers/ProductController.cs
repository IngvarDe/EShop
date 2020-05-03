using System;
using System.Linq;
using System.Threading.Tasks;
using EShop.Admin.Models.Product;
using EShop.Core.Dtos;
using EShop.Core.ServiceInterface;
using EShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using EShop.Admin.Controllers;

public class ProductController : BaseController
{
    private readonly IProductService _productService;
    private readonly EShopDbContext _context;
    private readonly IWebHostEnvironment _env;

    public ProductController
        (
        IProductService productService,
        EShopDbContext context,
        IWebHostEnvironment env
        )
    {
        _productService = productService;
        _context = context;
        _env = env;
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
    public async Task<IActionResult> Add(ProductViewModel model)
    {
        var dto = new ProductDto()
        {
            Id = model.Id,
            Description = model.Description,
            Name = model.Name,
            Value = model.Value,
            ModifiedAt = model.ModifiedAt,
            CreatedAt = model.CreatedAt,
            File = model.File,
            ExistingFilePath = model.ExistingFilePath
        };

        var result = await _productService.Add(dto);

        if (result == null)
        {
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction("index", model);
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
            ModifiedAt = product.ModifiedAt,
            ExistingFilePath = product.ExistingFilePath
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductViewModel model)
    {
        var dto = new ProductDto()
        {
            Id = model.Id,
            Description = model.Description,
            Name = model.Name,
            Value = model.Value,
            ModifiedAt = model.ModifiedAt,
            CreatedAt = model.CreatedAt,
            File = model.File,
            ExistingFilePath = model.ExistingFilePath
        };

        var result = await _productService.Update(dto);

        if (result == null)
        {
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction("index", model);
    }

    //private IActionResult Save(ProductViewModel model, bool isNew = false)
    //{
    //    var dto = new ProductDto()
    //    {
    //        Id = model.Id,
    //        Description = model.Description,
    //        Name = model.Name,
    //        Value = model.Value,
    //        ModifiedAt = model.ModifiedAt,
    //        CreatedAt = model.CreatedAt,
    //        File = model.File,
    //        ExistingFilePath = model.ExistingFilePath
    //    };

    //    var result = isNew
    //        ? _productService.Add(dto)
    //        : _productService.Update(dto);

    //    if (result == null)
    //    {
    //        return RedirectToAction(nameof(Index));
    //    }

    //    return RedirectToAction("index", model); //dosent refresh the imageFile
    //}

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
}
