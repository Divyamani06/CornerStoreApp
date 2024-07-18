using CornerStore.API.Dtos.RequestDtos;
using CornerStore.API.Dtos.ResponseDtos;
using CornerStore.API.Model;

namespace CornerStore.API.Services.IServices
{
    public interface IProductService
    {
        Task<ProductResponseDto> CreateProduct(ProductRequestDto product);
        Task DeleteProduct(Guid id);
        Task<List<ProductResponseDto>> GetAllProducts();
        Task<ProductResponseDto> GetProductById(Guid id);
        Task<ProductResponseDto> UpdateProduct(Guid id, ProductRequestDto product);
    }
}