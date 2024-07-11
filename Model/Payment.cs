using System.ComponentModel.DataAnnotations;

namespace CornerStore.API.Model
{
    public class Payment
    {
        [Key]
        public Guid PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? PaymentMethod { get; set; }
        public decimal Amount { get; set; }

        public Guid CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
