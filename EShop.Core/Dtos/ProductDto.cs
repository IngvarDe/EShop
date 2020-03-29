using EShop.Core.Domain;
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


        public static ProductDto FromProduct(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Value = product.Value
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
