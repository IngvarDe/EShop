using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Core.Domain
{
    public class Command
    {
        public Guid Id { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }
        public string Platfrom { get; set; }
    }
}
