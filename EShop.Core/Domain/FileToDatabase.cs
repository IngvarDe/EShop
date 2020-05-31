using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Core.Domain
{
    public class FileToDatabase
    {
        public Guid Id { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
    }
}
