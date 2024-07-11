using System.ComponentModel.DataAnnotations;

namespace CornerStore.API.Model
{
    public class Shipment
    {
        [Key]
        public Guid ShipmentId { get; set; }
        public DateTime ShipmentDate { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }

        public ICollection<Order> Orders { get; set; }
        public Guid CustmerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
