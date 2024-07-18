using CornerStore.API.Context;
using CornerStore.API.GenericRepository;
using CornerStore.API.Model;
using CornerStore.API.Repositories.Interfacese;

namespace CornerStore.API.Repositories
{
    public class CategoryRepository : UnitOfWork<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context):base(context) 
        {
            _context  = context;
        }
    }
}
