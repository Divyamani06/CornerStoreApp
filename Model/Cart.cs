using System.ComponentModel.DataAnnotations;

namespace CornerStore.API.Model
{
    public class Cart
    {
        [Key]
        public Guid CartId { get; set; }
        public int Quantity { get; set; }

        public Guid CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
