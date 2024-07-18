using CornerStore.API.Model;

namespace CornerStore.API.Repositories.IRepositories
{
    public interface IShipmentRepository
    {
        Task<Shipment> CreateShipment(Shipment shipment);
        Task DeleteShipment(Guid id);
        Task<IEnumerable<Shipment>> GetAllShipments();
        Task<Shipment> GetShipmentById(Guid id);
        Task UpdateShipment(Shipment shipment);
    }
}