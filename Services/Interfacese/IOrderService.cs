using CornerStore.API.Dtos.RequestDtos;
using CornerStore.API.Dtos.ResponseDtos;
using CornerStore.API.Model;

namespace CornerStore.API.Services.IServices
{
    public interface IOrderService
    {
        Task<OrderResponseDto> CreateOrder(OrderRequestDto order);
        Task DeleteOrder(Guid id);
        Task<List<OrderResponseDto>> GetAllOrders();
        Task<OrderResponseDto> GetOrderById(Guid id);
        Task<OrderResponseDto> UpdateOrder(Guid id, OrderRequestDto order);
    }
}