using CornerStore.API.Context;
using CornerStore.API.GenericRepository;
using CornerStore.API.Model;
using CornerStore.API.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CornerStore.API.Repositories
{
    public class ProductRepository : UnitOfWork<Product>, IProductRepository
    {
        private ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext):base(dbContext) 
        {
            _dbContext = dbContext;
        }

        
    }
}
