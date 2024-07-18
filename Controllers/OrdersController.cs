using CornerStore.API.Model;
using CornerStore.API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CornerStore.API.Controllers
{
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
            if (result == null) { return NotFound(); }
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
        public async Task<IActionResult> CreateOrder(Order order)
        {
            var result = await _orderService.CreateOrder(order);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id,Order order)
        {
            if(id != order.Id)
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
