using AutoMapper;
using CornerStore.API.Dtos.RequestDtos;
using CornerStore.API.Dtos.ResponseDtos;
using CornerStore.API.Model;
using CornerStore.API.Repositories.IRepositories;
using CornerStore.API.Services.IServices;

namespace CornerStore.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository,IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderResponseDto> CreateOrder(OrderRequestDto order)
        {
            var orderDetails = new OrderRequestDto
            {
                OrderDate = DateTime.Now,
                TotalPrice = order.TotalPrice,
                CustomerId = order.CustomerId,
                ShipmentId = order.ShipmentId,

            };
            var response = _mapper.Map<Order>(orderDetails);
            var result = await _orderRepository.AddAsync(response);
            return _mapper.Map<OrderResponseDto>(result);
         }

        public async Task<List<OrderResponseDto>> GetAllOrders()
        {
            var orderDetails = await _orderRepository.GetAll();
            var result = _mapper.Map<List<Order>>(orderDetails);
            return _mapper.Map<List<OrderResponseDto>>(result);

        }

        public async Task<OrderResponseDto> GetOrderById(Guid id)
        {
            var orderDetials = await _orderRepository.GetById(id);
            var result = _mapper.Map<Order>(orderDetials);
            return _mapper.Map<OrderResponseDto>(result);
        }

        public async Task<OrderResponseDto> UpdateOrder(Guid id, OrderRequestDto order)
        {
            var existingOrder = await _orderRepository.GetById(id);
            var details = new OrderRequestDto
            {
                OrderDate = order.OrderDate,
                ShipmentId = order.ShipmentId,
                CustomerId = existingOrder.CustomerId,
            };
            var response = _mapper.Map<Order>(details);
            var result = await _orderRepository.Update(response);
            return _mapper.Map<OrderResponseDto>(result);
        }

        public async Task DeleteOrder(Guid id)
        {
            await _orderRepository.Delete(id);
        }
    }
}
