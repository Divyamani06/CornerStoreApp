using CornerStore.API.Context;
using CornerStore.API.GenericRepository;
using CornerStore.API.Model;
using CornerStore.API.Repositories.IRepositories;

namespace CornerStore.API.Repositories
{
    public class OrderRepository :UnitOfWork<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext):base(dbContext) 
        {
            _dbContext = dbContext;
        }

    }
}
