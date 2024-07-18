using CornerStore.API.Dtos.RequestDtos;
using CornerStore.API.Dtos.ResponseDtos;

namespace CornerStore.API.Services.IServices
{
    public interface ICartService
    {
        //Task<CartResponseDto> CreatCart(CartResponseDto CartDto);
        Task<CartResponseDto> CreatCart( CartRequestDto cartDto);
        Task<Guid> DeteleCart(Guid id);
        Task<List<CartResponseDto>> GetAllCart();
        Task<CartResponseDto> GetByIdCart(Guid id);
        Task<CartResponseDto> UpdateCart(Guid id, CartRequestDto CartRequestDto);
    }
}