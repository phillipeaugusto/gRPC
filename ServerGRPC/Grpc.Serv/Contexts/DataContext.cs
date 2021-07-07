using System.Collections.Generic;
using DomainInfo.Entity;
using Microsoft.EntityFrameworkCore;

namespace ServerInfo.Contexts
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new List<Product>
            {
                new Product("Product 01", 10.10),
                new Product("Product 02", 12.12),
                new Product("Product 03", 13.13),

            });
        }
        public DbSet<Product> Products { get; set; }
    }
}
