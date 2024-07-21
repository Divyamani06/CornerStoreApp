namespace CornerStore.API.Dtos.RequestDtos
{
    public class OrderRequestDto
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public Guid CustomerId { get; set; }
        public Guid ShipmentId { get; set; }
    }
}
