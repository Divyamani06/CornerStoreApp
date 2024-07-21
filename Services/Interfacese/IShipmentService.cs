using CornerStore.API.Dtos.RequestDtos;
using CornerStore.API.Dtos.ResponseDtos;
using CornerStore.API.Model;

namespace CornerStore.API.Services.IServices
{
    public interface IShipmentService
    {
        Task<ShipmentResponseDto> CreateShipment(ShipmentRequestDto shipment);
        Task DeleteShipment(Guid id);
        Task<List<ShipmentResponseDto>> GetAllShipments();
        Task<ShipmentResponseDto> GetShipmentById(Guid id);
        Task<ShipmentResponseDto> UpdateShipment(Guid id, ShipmentRequestDto shipment);
    }
}