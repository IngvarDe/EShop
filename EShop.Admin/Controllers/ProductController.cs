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
using Microsoft.EntityFrameworkCore;


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
            Files = model.Files,
            ExistingFilePaths = model.ExistingFilePaths.Select(x => new ExistingFilePathDto
                {
                    Id = x.PhotoId,
                    ExistingFilePath = x.FilePath,
                    ProductId = x.ProductId
            }).ToArray()
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

        var photos = await _context.ExistingFilePath
            .Where(x => x.ProductId == id)
            .Select(m => new ExistingFilePathViewModel
            {
                FilePath = m.FilePath,
                PhotoId = m.Id
            })
            .ToArrayAsync();

        var model = new ProductViewModel();

        model.Id = product.Id;
        model.Description = product.Description;
        model.Name = product.Name;
        model.Value = product.Value;
        model.CreatedAt = product.CreatedAt;
        model.ModifiedAt = product.ModifiedAt;
        model.ExistingFilePaths.AddRange(photos);

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
            Files = model.Files,
            ExistingFilePaths = model.ExistingFilePaths.Select(x => new ExistingFilePathDto
            {
                Id = x.PhotoId,
                ExistingFilePath = x.FilePath,
                ProductId = x.ProductId
            })
        };

        var result = await _productService.Update(dto);

        if (result == null)
        {
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction("index", model);
    }

    [HttpPost]
    public async Task<IActionResult> RemoveImage(ExistingFilePathViewModel file)
    {
        var dto = new ExistingFilePathDto()
        {
            Id = file.PhotoId,
        };

        var photo = await _productService.RemoveImage(dto);
        if (photo == null)
        {
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        var product = await _productService.Delete(id);
        if (product == null)
        {
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction(nameof(Index), product);
    }
}
