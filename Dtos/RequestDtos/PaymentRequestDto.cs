namespace CornerStore.API.Dtos.RequestDtos
{
    public class PaymentRequestDto
    {
        public DateTime PaymentDate { get; set; }
        public string? PaymentMethod { get; set; }
        public decimal Amount { get; set; }

        public Guid CustomerId { get; set; }
    }
}
