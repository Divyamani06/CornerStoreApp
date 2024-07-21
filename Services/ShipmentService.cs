using AutoMapper;
using CornerStore.API.Dtos.RequestDtos;
using CornerStore.API.Dtos.ResponseDtos;
using CornerStore.API.Model;
using CornerStore.API.Repositories.IRepositories;
using CornerStore.API.Services.IServices;

namespace CornerStore.API.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;

        public ShipmentService(IShipmentRepository shipmentRepository,IMapper mapper)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
        }

        public async Task<ShipmentResponseDto> CreateShipment(ShipmentRequestDto shipment)
        {
            var details = new ShipmentRequestDto
            {
                ShipmentDate = shipment.ShipmentDate,
                State = shipment.State,
                Address = shipment.Address,
                City = shipment.City,
                Country = shipment.Country,
                CustomerId = shipment.CustomerId,
                ZipCode = shipment.ZipCode,
            };
            var response = _mapper.Map<Shipment>(details);
            var result = await _shipmentRepository.AddAsync(response);
            return _mapper.Map<ShipmentResponseDto>(result);
        }

        public async Task<List<ShipmentResponseDto>> GetAllShipments()
        {
            var shipmentDetails = await _shipmentRepository.GetAll();
            var result = _mapper.Map<List<Shipment>>(shipmentDetails);
            return _mapper.Map<List<ShipmentResponseDto>>(result);
        }

        public async Task<ShipmentResponseDto> GetShipmentById(Guid id)
        {
            var shipmentDetials = await _shipmentRepository.GetById(id);
            var result = _mapper.Map<Shipment>(shipmentDetials);
            return _mapper.Map<ShipmentResponseDto>(result);
        }

        public async Task<ShipmentResponseDto> UpdateShipment(Guid id, ShipmentRequestDto shipment)
        {
            var existingShipment = await _shipmentRepository.GetById(id);
            var details = new ShipmentRequestDto
            {
                ShipmentDate = DateTime.Now,
                Address = shipment.Address,
                State = shipment.State,
                City = shipment.City,
                Country = shipment.Country,
                CustomerId = shipment.CustomerId,
                ZipCode = shipment.ZipCode
            };
            var response = _mapper.Map<Shipment>(details);
            var result = await _shipmentRepository.Update(response);
            return _mapper.Map<ShipmentResponseDto>(result);
        }

        public async Task DeleteShipment(Guid id)
        {
            await _shipmentRepository.Delete(id);
        }
    }
}
