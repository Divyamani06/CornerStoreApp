using CornerStore.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CornerStore.API.Configurations
{
    public class OrderEntityConfiguration:IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.ToTable("Orders");
            entity.HasKey(t => t.Id);
            entity.Property(p => p.OrderDate).IsRequired();

            entity.HasMany(h => h.OrderItems).WithOne(x => x.Order).HasForeignKey(x => x.OrderId).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
