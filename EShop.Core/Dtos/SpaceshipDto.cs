using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Core.Dtos
{
    public class SpaceshipDto
    {
        public Guid? Id { get; set; }
        //public string Name { get; set; }
        public int CrewSize { get; set; }
        public string Armament { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();
    }
}
