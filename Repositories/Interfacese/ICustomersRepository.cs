using CornerStore.API.GenericRepository;
using CornerStore.API.Model;

namespace CornerStore.API.Repositories.IRepositories
{
    public interface ICustomersRepository : IUnitOfWork<Customer>
    {
        Task<string> SignIn(string email, string password);
    }
}