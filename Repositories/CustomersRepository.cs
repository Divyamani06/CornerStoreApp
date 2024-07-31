using CornerStore.API.Authenticaion;
using CornerStore.API.Context;
using CornerStore.API.GenericRepository;
using CornerStore.API.Model;
using CornerStore.API.Repositories.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CornerStore.API.Repositories
{
    public class CustomersRepository :UnitOfWork<Customer>, ICustomersRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomersRepository(ApplicationDbContext context) :base(context) 
        {
            _context = context;
        }

    }
}
