using CornerStore.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CornerStore.API.Configurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.ToTable("Products");
            entity.HasKey(x => x.Id);
            entity.Property(e => e.SKU).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Stock).IsRequired();
            entity.Property(e => e.Description).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Price).IsRequired();

            entity.HasMany(e => e.Wishlists).WithOne(p => p.Product).HasForeignKey(p => p.ProductId);
            entity.HasMany(e => e.Carts).WithOne(p => p.Product).HasForeignKey(p => p.ProductId);
            entity.HasMany(e => e.OrderItems).WithOne(p => p.Product).HasForeignKey(p => p.ProductId);
        }
    }
}
