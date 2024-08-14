using CornerStore.API.Dtos.ResponseDtos;
using CornerStore.API.Models;

namespace CornerStore.API.Services.Interfacese
{
    public interface IUserAuthService
    {
        Task<(string, CustomerResponseDto)> CreateUser(RegisterModel model);
        Task<string> UserSignIn(string email, string password);
    }
}