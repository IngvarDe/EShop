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
        public string ExistingFilePath { get; set; }
        //public IEnumerable<FileDescriptionShort> Resources { get; set; } = new List<FileDescriptionShort>();
    }

    //public class FileDescriptionShort
    //{
    //    public Guid? Id { get; set; }
    //    public bool IsNew { get; set; }
    //    public IFormFile File { get; set; }
    //    //public ResourceType ResourceType { get; set; }
    //    public string ResourceUrl { get; set; }
    //    public string Title { get; set; }
    //    public string ExternalUrl { get; set; }
    //}

    //public class FileResult
    //{
    //    public List<string> FileNames { get; set; }
    //    public string Description { get; set; }
    //    public DateTime CreatedAt { get; set; }
    //    public DateTime ModifiedAt { get; set; }
    //    public List<string> ContentTypes { get; set; }
    //}

    //public class FileDescription
    //{
    //    public List<string> FileNames { get; set; }
    //    public string Description { get; set; }
    //    public DateTime CreatedAt { get; set; }
    //    public DateTime ModifiedAt { get; set; }
    //    public string ContentTypes { get; set; }
    //}
}
