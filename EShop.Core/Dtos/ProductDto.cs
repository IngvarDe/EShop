using EShop.Core.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;


namespace EShop.Core.Dtos
{
    public class ProductDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public IFormFile File { get; set; }
        public string ExistingFilePath { get; set; }


        public static ProductDto FromProduct(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Value = product.Value,
                CreatedAt = product.CreatedAt,
                ModifiedAt = product.ModifiedAt,
                ExistingFilePath = product.ExistingFilePath
            };
        }

        public static IEnumerable<ProductDto> FromProducts(IEnumerable<Product> products)
        {
            if (products == null)
            {
                return new List<ProductDto>();
            }
            return products.Select(product => FromProduct(product));
        }
    }
}
