namespace CornerStore.API.Dtos.ResponseDtos
{
    public class CartResponseDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
    }

}
