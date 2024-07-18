using System.ComponentModel.DataAnnotations;

namespace CornerStore.API.Model
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public Guid CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        public Guid ShipmentId { get; set; }
        public virtual Shipment? Shipment { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
