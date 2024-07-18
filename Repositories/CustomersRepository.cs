using CornerStore.API.Context;
using CornerStore.API.GenericRepository;
using CornerStore.API.Model;
using CornerStore.API.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CornerStore.API.Repositories
{
    public class CustomersRepository :UnitOfWork<Customer>, ICustomersRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomersRepository(ApplicationDbContext context) :base(context) 
        {
            _context = context;
        }


        public async Task<string> SignIn(string email, string password)
        {
            var passwordEncrypt = EncryptPassword(password!);

            var signup = await _context.Customers.FirstOrDefaultAsync(x=>x.Email==email&&x.Password==passwordEncrypt);
            if(signup == null)
            {
                return "customer is not found";
            }
            return "customer login successfully";
            
        }
    }
}
