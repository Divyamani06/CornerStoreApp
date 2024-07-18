using System.ComponentModel.DataAnnotations;

namespace CornerStore.API.Model
{
    public class Wishlist
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
