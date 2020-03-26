using EShop.Core.Domain;
using EShop.Core.Dtos;
using EShop.Core.ServiceInterface;
using EShop.Core.ServiceResult;
using EShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EShop.ApplicationServices.Products
{
    public class ProductsService : IProductService
    {
        private EShopDbContext _context { get; set; }

        public ProductsService(EShopDbContext context)
        {
            _context = context;
        }

        public ServiceResult<Product> Save(ProductDto dto)
        {
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                Value = dto.Value
            };

            _context.Product.Add(product);
            _context.SaveChanges();
            return ServiceResult<Product>.Ok(product);
        }

        public ServiceResult<Product> Edit(ProductDto dto)
        {
            Product product = new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Value = dto.Value
            };

            _context.Product.Add(product);
            _context.SaveChanges();
            return ServiceResult<Product>.Ok(product);
        }

        public ServiceResults Delete(ProductDto dto)
        {
            var productId = _context.Product
                .FirstOrDefault(x => x.Id == dto.Id);

            _context.Product.Remove(productId);

            return ServiceResults.Ok();
        }

        //public ServiceResults ProductGrid()
        //{
        //    var result = _context.Product
        //        .Select(x => new ProductDto
        //        {
        //            Id = x.Id,
        //            Description = x.Description,
        //            Name = x.Name,
        //            Value = x.Value
        //        });

        //    return ServiceResults.Ok();
        //}
    }
}
