using CornerStore.API.Context;
using CornerStore.API.GenericRepository;
using CornerStore.API.Model;
using CornerStore.API.Repositories.IRepositories;

namespace CornerStore.API.Repositories
{
    public class ShipmentRepository :UnitOfWork<Shipment>, IShipmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ShipmentRepository(ApplicationDbContext dbContext):base(dbContext) 
        {
            _dbContext = dbContext;
        }

    }
}
