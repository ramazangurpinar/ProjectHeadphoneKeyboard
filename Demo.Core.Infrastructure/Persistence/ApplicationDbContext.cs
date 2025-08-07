using Microsoft.EntityFrameworkCore;
using Demo.Core.Domain.Entities;

namespace Demo.Core.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Headphone> Headphones { get; set; }
        public DbSet<Keyboard> Keyboards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasDiscriminator<string>(nameof(Product.ProductType))
                .HasValue<Headphone>("Headphone")
                .HasValue<Keyboard>("Keyboard");
        }
    }
}