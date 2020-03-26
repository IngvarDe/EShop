using EShop.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace EShop.Data
{
    public class EShopDbContext : IdentityDbContext
    {
        public EShopDbContext(DbContextOptions<EShopDbContext> options)
            : base(options) { }

        public DbSet<Product> Product { get; set; }
    }
}
