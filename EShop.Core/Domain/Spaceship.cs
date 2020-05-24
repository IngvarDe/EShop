using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Core.Domain
{
    public class Spaceship
    {
        public Guid Id { get; set; }
        public int CrewSize { get; set; }
        public string Armament { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
