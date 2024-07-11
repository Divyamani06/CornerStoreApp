using Microsoft.EntityFrameworkCore;
using CornerStore.API.Model;

namespace CornerStore.API.Context
{
    public class ApplicationDbContext :DbContext
    { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(50);
                entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Address).HasMaxLength(100);
                entity.Property(e => e.Password).HasMaxLength(50);
            });
            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.Property(p => p.ShipmentDate).IsRequired();
                entity.Property(p => p.Address).HasMaxLength(100);
                entity.Property(p => p.State).HasMaxLength(50);
                entity.Property(p => p.City).HasMaxLength(50);
                entity.Property(p => p.ZipCode).IsRequired();

                entity.HasOne(h => h.Customer).WithMany(x=>x.Shipments).HasForeignKey(x => x.CustmerId);
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(p => p.OrderDate).IsRequired();

                entity.HasOne(h => h.Shipment).WithMany(x => x.Orders).HasForeignKey(x => x.ShipmentId);
                entity.HasOne(h => h.Customer).WithMany(x => x.Orders).HasForeignKey(x => x.CustomerId);
            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(p => p.Name).IsRequired().HasMaxLength(50);
            });
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(p => p.Quantity).IsRequired();
                entity.Property(p => p.Price).IsRequired();

                entity.HasOne(h => h.Order).WithMany(o => o.OrderItems).HasForeignKey(o => o.OrderId);
                entity.HasOne(h => h.Product).WithMany(p => p.OrderItems).HasForeignKey(p => p.ProductId);
            });
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(p => p.Quantity).IsRequired();

                entity.HasOne(h => h.Product).WithMany(p => p.Carts).HasForeignKey(p => p.ProductId);
                entity.HasOne(h => h.Customer).WithMany(c => c.Carts).HasForeignKey(c => c.CustomerId);
            });
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentDate).IsRequired();
                entity.Property(e => e.PaymentMethod).IsRequired();

                entity.HasOne(h => h.Customer).WithMany(c => c.Payments).HasForeignKey(c => c.CustomerId);
            });
            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.HasOne(h => h.Customer).WithMany(c => c.Wishlists).HasForeignKey(c => c.CustomerId);
                entity.HasOne(h => h.Product).WithMany(p => p.Wishlists).HasForeignKey(p => p.ProductId);
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.SKU).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Stock).IsRequired();
                entity.Property(e => e.Description).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Price).IsRequired();

                entity.HasOne(h => h.Category).WithMany(c => c.Products).HasForeignKey(h => h.CategoryId);
            });
            
        }
    }
}
