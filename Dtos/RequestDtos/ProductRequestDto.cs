namespace CornerStore.API.Dtos.RequestDtos
{
    public class ProductRequestDto
    {
        public Guid Id { get; set; }
        public string? SKU { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Guid CategoryId { get; set; }
    }
}
