using CornerStore.API.Dtos.ResponseDtos;
using CornerStore.API.Models;

namespace CornerStore.API.Services.Interfacese
{
    public interface IAdminAuthService
    {
        Task<string> AdminSignIn(string email, string password);
        Task<(string, CustomerResponseDto)> AdminSignUp(RegisterModel model);
    }
}