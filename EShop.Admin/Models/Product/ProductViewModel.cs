﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace EShop.Admin.Models.Product
{
    public class ProductViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<ExistingFilePathViewModel> ExistingFilePaths { get; set; } = new List<ExistingFilePathViewModel>();
    }

    public class ExistingFilePathViewModel
    {
        public Guid PhotoId { get; set; }
        public string FilePath { get; set; }
        public Guid ProductId { get; set; }
    }
}
