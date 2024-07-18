using CornerStore.API.Model;
using CornerStore.API.Repositories.IRepositories;
using CornerStore.API.Services.IServices;

namespace CornerStore.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            var orderDetails = new Order
            {
                Id = order.Id,
                OrderDate = DateTime.Now,
                TotalPrice = order.TotalPrice,

            };
            await _orderRepository.CreateOrder(orderDetails);
            return orderDetails;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            var orderDetails = await _orderRepository.GetAllOrders();
            return orderDetails.Select(x => new Order
            {
                Id = x.Id,
                OrderDate = DateTime.Now,
                TotalPrice = x.TotalPrice,
                CustomerId = x.CustomerId,
            });

        }

        public async Task<Order> GetOrderById(Guid id)
        {
            var orderDetials = await _orderRepository.GetOrderBtId(id);
            return new Order { Id = orderDetials.Id, OrderDate = DateTime.Now, TotalPrice = orderDetials.TotalPrice, };
        }

        public async Task UpdateOrder(Guid id, Order order)
        {
            var existingOrder = await _orderRepository.GetOrderBtId(id);
            existingOrder.TotalPrice = order.TotalPrice;
            existingOrder.OrderDate = DateTime.Now;
            await _orderRepository.UpdateOrder(existingOrder);
        }

        public async Task DeleteOrder(Guid id)
        {
            await _orderRepository.DeleteOrder(id);
        }
    }
}
