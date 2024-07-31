using Microsoft.AspNetCore.Identity;

namespace CornerStore.API.Model
{
    public class Customer : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }

        public  ICollection<Order> Orders { get; set; }
        public  ICollection<Payment> Payments { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }
        public ICollection<Shipment> Shipments { get; set; }
    }
}
