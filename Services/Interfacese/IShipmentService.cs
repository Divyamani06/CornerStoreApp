using CornerStore.API.Model;

namespace CornerStore.API.Services.IServices
{
    public interface IShipmentService
    {
        Task<Shipment> CreateShipment(Shipment shipment);
        Task DeleteShipment(Guid id);
        Task<IEnumerable<Shipment>> GetAllShipments();
        Task<Shipment> GetShipmentById(Guid id);
        Task<Shipment> UpdateShipment(Guid id, Shipment shipment);
    }
}