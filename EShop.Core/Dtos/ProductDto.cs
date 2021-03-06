﻿using EShop.Core.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Core.Dtos
{
    public class ProductDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public List<IFormFile> Files { get; set; }
        public IEnumerable<ExistingFilePathDto> ExistingFilePaths { get; set; } = new List<ExistingFilePathDto>();


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
                ExistingFilePaths = product.ExistingFilePaths.Select(x => new ExistingFilePathDto
                {
                    Id = x.Id,
                    ExistingFilePath = x.FilePath,
                    ProductId = x.ProductId
                }).ToArray()
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
