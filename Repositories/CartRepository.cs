using CornerStore.API.Context;
using CornerStore.API.GenericRepository;
using CornerStore.API.Model;
using CornerStore.API.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CornerStore.API.Repositories
{
    public class CartRepository : UnitOfWork<Cart>, ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context): base(context) 
        {
            _context = context;
        }

        public async Task<List<Cart>> GetCartByCustomer(Guid id)
        {
             var res = await  _context.Carts.Include(c => c.Product).Where(c => c.CustomerId == id).ToListAsync();
            return res;
        }
    }
}
