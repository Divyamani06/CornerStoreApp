using CornerStore.API.Model;

namespace CornerStore.API.Repositories.IRepositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrder(Order order);
        Task DeleteOrder(Guid id);
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> GetOrderBtId(Guid id);
        Task UpdateOrder(Order order);
    }
}