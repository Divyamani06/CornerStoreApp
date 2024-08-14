using CornerStore.API.Model;
using CornerStore.API.Models;
using CornerStore.API.Repositories.Interfacese;
using Microsoft.AspNetCore.Identity;

namespace CornerStore.API.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly UserManager<Customer> _userManager;
        private readonly RoleManager<CustomerRole> _roleManager;

        public AuthenticationRepository(UserManager<Customer> userManager, RoleManager<CustomerRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Customer?> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityResult> CreateAsync(Customer customer, string password)
        {
            return await _userManager.CreateAsync(customer, password);
        }

        public async Task<IdentityResult> AddToRoleAsync(Customer customer, string role)
        {
            return await _userManager.AddToRoleAsync(customer, role);
        }

        public async Task<IdentityResult> DeleteAsync(Customer customer)
        {
            return await _userManager.DeleteAsync(customer);
        }

        public async Task<bool> CheckPasswordAsync(Customer customer, string password)
        {
            return await _userManager.CheckPasswordAsync(customer, password);
        }

        public async Task<IList<string>> GetRolesAsync(Customer customer)
        {
            return await _userManager.GetRolesAsync(customer);
        }

        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }

        public async Task<IdentityResult> CreateAsync(CustomerRole customer)
        {
            return await _roleManager.CreateAsync(customer);
        }

    }
}
