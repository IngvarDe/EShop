﻿using EShop.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace EShop.Data
{
    public class EShopDbContext : IdentityDbContext
    {
        public EShopDbContext(DbContextOptions<EShopDbContext> options)
            : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<ExistingFilePath> ExistingFilePath { get; set; }
        public DbSet<Spaceship> Spaceship { get; set; }
        public DbSet<FileToDatabase> FileToDatabase { get; set; }
        public DbSet<Command> Command { get; set; }
    }
}
