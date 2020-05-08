using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace EShop.Admin.Models.Product
{
    public class ProductViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public IFormFile File { get; set; }
        public List<IFormFile> Files { get; set; }
        public string ExistingFilePath { get; set; }
        public IEnumerable<ExistingFilePathViewModel> ExistingFilePaths { get; set; } = new List<ExistingFilePathViewModel>();
    }

    public class ExistingFilePathViewModel
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; }
    }
}
