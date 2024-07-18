using CornerStore.API.GenericRepository;
using CornerStore.API.Model;

namespace CornerStore.API.Repositories.IRepositories
{
    public interface ICartRepository : IUnitOfWork<Cart>
    {
        Task<List<Cart>> GetCartByCustomer(Guid customerId);
    }
}
