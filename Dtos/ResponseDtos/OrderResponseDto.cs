namespace CornerStore.API.Dtos.ResponseDtos
{
    public class OrderResponseDto
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public Guid CustomerId { get; set; }
        public Guid ShipmentId { get; set; }
    }
}
