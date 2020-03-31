using EShop.Core.Domain;
using EShop.Core.Dtos;
using EShop.Core.ServiceInterface;
using EShop.Core.ServiceResult;
using EShop.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.ApplicationServices.Products
{
    public class ProductsService : IProductService
    {
        static EShopDbContext _context { get; set; }

        public ProductsService(EShopDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetAsync(Guid id)
        {
            var result = await _context.Product
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Product> Add(ProductDto dto)
        {
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                Value = dto.Value,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Update(ProductDto dto)
        {
            Product product = new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Value = dto.Value,
                CreatedAt = dto.CreatedAt, //todo dosent save old created at
                ModifiedAt = DateTime.Now
            };

            _context.Product.Update(product);
            await _context.SaveChangesAsync();
            return product;

            //var result = _productService.Update(dto);
            //if (!result.IsSuccess)
            //{
            //    Response.StatusCode = ApplicationHttpStatusCodes.ValidationError;
            //    return Json(ModelState.Errors());
            //}
        }

        public ServiceResults Delete(ProductDto dto)
        {
            var productId = _context.Product
                .FirstOrDefault(x => x.Id == dto.Id);

            _context.Product.Remove(productId);

            return ServiceResults.Ok();
        }
    }
}
