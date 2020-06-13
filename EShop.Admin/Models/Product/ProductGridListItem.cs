using System;


namespace EShop.Admin.Models.Product
{
    public class ProductGridListItem
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
    }
}
