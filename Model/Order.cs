using System.ComponentModel.DataAnnotations;

namespace CornerStore.API.Model
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public Guid CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        public Guid ShipmentId { get; set; }
        public virtual Shipment? Shipment { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
