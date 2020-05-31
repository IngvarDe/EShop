using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Admin.Models.Spaceship
{
    public class SpaceshipGridListItem
    {
        public Guid? Id { get; set; }
        public int CrewSize { get; set; }
        public string Armament { get; set; }
        public string Role { get; set; }
    }
}
