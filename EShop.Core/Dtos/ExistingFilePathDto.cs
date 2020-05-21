using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;


namespace EShop.Core.Dtos
{
    public class ExistingFilePathDto
    {
        public Guid Id { get; set; }
        public string ExistingFilePath { get; set; }
        public Guid? ProductId { get; set; }
    }
}
