using CornerStore.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CornerStore.API.Configurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.ToTable("Categories");
            entity.HasKey(c => c.Id);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(50);

            entity.HasMany(e => e.Products).WithOne(c => c.Category).HasForeignKey(x => x.CategoryId);
        }
    }
}
