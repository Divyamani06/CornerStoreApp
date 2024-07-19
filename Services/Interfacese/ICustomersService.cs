using CornerStore.API.Dtos.RequestDtos;
using CornerStore.API.Dtos.ResponseDtos;
using CornerStore.API.Model;

namespace CornerStore.API.Services.IServices
{
    public interface ICustomersService
    {
        Task<CustomerResponseDto> CreatCustomer(CustomerRequestDto customerDto);
        Task<Guid> DeteleCustomer(Guid id);
        Task<List<CustomerResponseDto>> GetAllCustomer();
        Task<CustomerResponseDto> GetByIdCustomer(Guid id);
        Task<bool> SignIn(string email, string password);
        Task<CustomerResponseDto> UpdateCustomer(Guid id, CustomerRequestDto customerRequestDto);
    }
}