using CornerStore.API.Model;

namespace CornerStore.API.Services.IServices
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(Order order);
        Task DeleteOrder(Guid id);
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> GetOrderById(Guid id);
        Task UpdateOrder(Guid id, Order order);
    }
}