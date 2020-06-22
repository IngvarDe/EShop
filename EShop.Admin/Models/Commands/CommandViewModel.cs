using System;


namespace EShop.Admin.Models.Commander
{
    public class CommandViewModel
    {
        public Guid Id { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }
        public string Platfrom { get; set; }
    }
}
