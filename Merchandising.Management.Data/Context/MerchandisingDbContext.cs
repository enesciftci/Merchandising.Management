using Merchandising.Management.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Merchandising.Management.Data.Context
{
    public class MerchandisingDbContext : DbContext
    {
        public MerchandisingDbContext(DbContextOptions<MerchandisingDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId);
            });
        }
    }
}
