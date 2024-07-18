using CornerStore.API.Model;
using CornerStore.API.Repositories.IRepositories;
using CornerStore.API.Services.IServices;

namespace CornerStore.API.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository _shipmentRepository;

        public ShipmentService(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        public async Task<Shipment> CreateShipment(Shipment shipment)
        {
            var shipmentDetails = new Shipment
            {
                Id = shipment.Id,
                ShipmentDate = shipment.ShipmentDate,
                State = shipment.State,
                City = shipment.City,
                ZipCode = shipment.ZipCode,
                Address = shipment.Address,
                Country = shipment.Country,
            };
            await _shipmentRepository.CreateShipment(shipmentDetails);
            return shipment;
        }

        public async Task<IEnumerable<Shipment>> GetAllShipments()
        {
            var details = await _shipmentRepository.GetAllShipments();
            return details.Select(x => new Shipment
            {
                Id = x.Id,
                ShipmentDate = x.ShipmentDate,
                State = x.State,
                Address = x.Address,
                Country = x.Country,
                City = x.City,
                ZipCode = x.ZipCode,
            });
        }

        public async Task<Shipment> GetShipmentById(Guid id)
        {
            var details = await _shipmentRepository.GetShipmentById(id);

            return new Shipment { Id = details.Id, 
                ShipmentDate = details.ShipmentDate,
                State = details.State,
                City = details.City, 
                ZipCode = details.ZipCode,
                Address = details.Address 
            };
        }

        public async Task<Shipment> UpdateShipment(Guid id, Shipment shipment)
        {
            var existingShipment = await _shipmentRepository.GetShipmentById(id);
            existingShipment.ShipmentDate = shipment.ShipmentDate;
            existingShipment.State = shipment.State;
            existingShipment.City = shipment.City;
            existingShipment.ZipCode = shipment.ZipCode;
            existingShipment.Address = shipment.Address;
            existingShipment.Country = shipment.Country;
            await _shipmentRepository.UpdateShipment(existingShipment);
            return shipment;
        }

        public async Task DeleteShipment(Guid id)
        {
            await _shipmentRepository.DeleteShipment(id);
        }
    }
}
