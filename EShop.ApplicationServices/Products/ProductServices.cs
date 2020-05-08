﻿using EShop.Core.Domain;
using EShop.Core.Dtos;
using EShop.Core.ServiceInterface;
using EShop.Core.ServiceResult;
using EShop.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;

namespace EShop.ApplicationServices.Products
{
    public class ProductsService : IProductService
    {
        static EShopDbContext _context { get; set; }
        private readonly IWebHostEnvironment _env;

        public ProductsService(
            EShopDbContext context,
            IWebHostEnvironment env)
        {
            _env = env;
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
            string uniqueFileName = ProcessUploadedFile(dto);

            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                Value = dto.Value,
                ExistingFilePaths = dto.ExistingFilePaths.Select(x => new ExistingFilePath
                {
                    Id = x.Id,
                    FilePath = uniqueFileName
                }).ToArray(),

                //ExistingFilePath = uniqueFileName,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Update(ProductDto dto)
        {
            Product product = new Product();

            product.Id = dto.Id;
            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Value = dto.Value;
            product.CreatedAt = dto.CreatedAt;
            product.ModifiedAt = DateTime.Now;

            if (dto.File != null)
            {
                if (dto.ExistingFilePath != null)
                {
                    string filePath = Path.Combine(_env.WebRootPath, "multipleFileUpload", dto.ExistingFilePath);
                    File.Delete(filePath);
                }
                product.ExistingFilePath = ProcessUploadedFile(dto);
            }

            _context.Product.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Delete(Guid id)
        {
            var productId = await _context.Product
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Product.Remove(productId);
            await _context.SaveChangesAsync();

            return productId;
        }

        public string ProcessUploadedFile(ProductDto dto)
        {
            string uniqueFileName = null;
            if (dto.File != null)
            {
                foreach (var item in dto.Files)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "multipleFileUpload");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + dto.File.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        dto.File.CopyTo(fileStream);
                    }
                }

            }

            return uniqueFileName;
        }
    }
}
