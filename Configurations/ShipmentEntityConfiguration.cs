using CornerStore.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CornerStore.API.Configurations
{
    public class ShipmentEntityConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> entity)
        {
            entity.ToTable("Shipment");
            entity.HasKey(x => x.Id);
            entity.Property(p => p.ShipmentDate).IsRequired();
            entity.Property(p => p.Address).HasMaxLength(100);
            entity.Property(p => p.State).HasMaxLength(50);
            entity.Property(p => p.City).HasMaxLength(50);
            entity.Property(p => p.ZipCode).IsRequired();

            entity.HasMany(h => h.Orders).WithOne(x => x.Shipment).HasForeignKey(x => x.ShipmentId).IsRequired();
        }
    }
}
