using CornerStore.API.Model;
using CornerStore.API.Models;
using Microsoft.AspNetCore.Identity;

namespace CornerStore.API.Repositories.Interfacese
{
    public interface IAuthenticationRepository
    {
        Task<IdentityResult> AddToRoleAsync(Customer customer, string role);
        Task<bool> CheckPasswordAsync(Customer customer, string password);
        Task<IdentityResult> CreateAsync(Customer customer, string password);
        Task<IdentityResult> CreateAsync(CustomerRole customer);
        Task<IdentityResult> DeleteAsync(Customer customer);
        Task<Customer> FindByEmailAsync(string email);
        Task<IList<string>> GetRolesAsync(Customer customer);
        Task<bool> RoleExistsAsync(string roleName);
    }
}