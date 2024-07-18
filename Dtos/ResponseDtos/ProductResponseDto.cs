﻿namespace CornerStore.API.Dtos.ResponseDtos
{
    public class ProductResponseDto
    {
        public Guid Id { get; set; }
        public string? SKU { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Guid CategoryId { get; set; }
    }
}
