using CornerStore.API.Dtos.RequestDtos;
using CornerStore.API.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CornerStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;

        public ShipmentsController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllShipment()
        {
            var result = await _shipmentService.GetAllShipments();
            if(result.Count() == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetShipmentById(Guid id)
        {
            var result = await _shipmentService.GetShipmentById(id);
            if (result == null) { return NotFound(); }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateShipment(ShipmentRequestDto shipment)
        {
            var result = await _shipmentService.CreateShipment(shipment);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShipment(Guid id, ShipmentRequestDto shipment)
        {
            if (id == null)
            {
                return BadRequest();
            }
            await _shipmentService.UpdateShipment(id, shipment);
            return Ok(shipment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipment(Guid id)
        {
            await _shipmentService.DeleteShipment(id);
            return Ok(id);
        }
    }
}
