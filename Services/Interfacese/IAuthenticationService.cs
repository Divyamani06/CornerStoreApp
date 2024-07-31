using CornerStore.API.Dtos.ResponseDtos;
using CornerStore.API.Models;

namespace CornerStore.API.Services.Interfacese
{
    public interface IAuthenticationService
    {
        Task<string> CreateRoles();
        Task<string> SignIn(string email, string password);
        Task<(string, CustomerResponseDto)> SignUp(RegisterModel model);
    }
}