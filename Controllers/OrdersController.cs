using CornerStore.API.Dtos.RequestDtos;
using CornerStore.API.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CornerStore.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            var result = await _orderService.GetAllOrders();
            if (result == null) 
            {
                return NotFound(); 
            }
            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var result = await _orderService.GetOrderById(id);
            if (result == null) { return NotFound(); }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderRequestDto order)
        {
            var result = await _orderService.CreateOrder(order);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, OrderRequestDto order)
        {
            if(id == null)
            {
                return BadRequest();
            }
            await _orderService.UpdateOrder(id, order);
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            await _orderService.DeleteOrder(id);
            return Ok(id);
        }
    }
}
