using CornerStore.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CornerStore.API.Configurations
{
    public class CartEntityConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> entity)
        {
            entity.ToTable("Carts");
            entity.HasKey(x=>x.Id);
            entity.Property(p => p.Quantity).IsRequired();
        }
    }
}
