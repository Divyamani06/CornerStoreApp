namespace CornerStore.API.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? SKU { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public  ICollection<OrderItem>? OrderItems { get; set; } 
        public  ICollection<Cart>? Carts { get; set; }
        public  ICollection<Wishlist>? Wishlists { get; set; }
    }
}
