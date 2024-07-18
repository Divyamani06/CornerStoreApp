using CornerStore.API.Context;
using CornerStore.API.Model;
using CornerStore.API.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CornerStore.API.Repositories
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ShipmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Shipment> CreateShipment(Shipment shipment)
        {
            await _dbContext.AddAsync(shipment);
            await _dbContext.SaveChangesAsync();
            return shipment;
        }

        public async Task<IEnumerable<Shipment>> GetAllShipments()
        {
            return await _dbContext.Shipments.ToListAsync();
        }

        public async Task<Shipment> GetShipmentById(Guid id)
        {
            return await _dbContext.Shipments.FindAsync(id);
        }

        public async Task UpdateShipment(Shipment shipment)
        {
            _dbContext.Shipments.Update(shipment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteShipment(Guid id)
        {
            var details = await _dbContext.Shipments.FindAsync(id);
            if (details != null)
            {
                _dbContext.Remove(details);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
