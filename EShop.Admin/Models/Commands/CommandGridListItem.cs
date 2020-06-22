using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Admin.Models.Commander
{
    public class CommandGridListItem
    {
        public Guid Id { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }
        public string Platfrom { get; set; }
    }
}
