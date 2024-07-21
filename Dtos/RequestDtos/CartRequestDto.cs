using CornerStore.API.Model;

namespace CornerStore.API.Dtos.RequestDtos
{
    public class CartRequestDto
    {
        public int Quantity { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
    }
}
