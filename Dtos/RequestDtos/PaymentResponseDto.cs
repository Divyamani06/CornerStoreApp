namespace CornerStore.API.Dtos.RequestDtos
{
    public class PaymentResponseDto
    {
        public Guid Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? PaymentMethod { get; set; }
        public decimal Amount { get; set; }

        public Guid CustomerId { get; set; }
    }
}
