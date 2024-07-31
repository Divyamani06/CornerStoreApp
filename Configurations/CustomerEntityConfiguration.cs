using CornerStore.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CornerStore.API.Configurations
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.ToTable("Customers");
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.HasMany(e => e.Orders).WithOne(c => c.Customer).HasForeignKey(c => c.CustomerId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            entity.HasMany(e=>e.Wishlists).WithOne(c=>c.Customer).HasForeignKey(c => c.CustomerId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            entity.HasMany(e => e.Shipments).WithOne(c => c.Customer).HasForeignKey(c => c.CustomerId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            entity.HasMany(e=>e.Carts).WithOne(c=>c.Customer).HasForeignKey(c => c.CustomerId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            entity.HasMany(e => e.Payments).WithOne(c => c.Customer).HasForeignKey(c => c.CustomerId).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
