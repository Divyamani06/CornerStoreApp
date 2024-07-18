using CornerStore.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CornerStore.API.Configurations
{
    public class OrderItemEntityConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> entity)
        {
            entity.ToTable("OrderItems");
            entity.HasKey(x => x.Id);
            entity.Property(p => p.Quantity).IsRequired();
            entity.Property(p => p.Price).IsRequired();
        }
    }
}
