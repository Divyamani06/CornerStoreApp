using CornerStore.API.Dtos.RequestDtos;
using CornerStore.API.Dtos.ResponseDtos;
using CornerStore.API.Model;

namespace CornerStore.API.Services.IServices
{
    public interface ICustomersService
    {
        Task<Guid> DeteleCustomer(Guid id);
        Task<List<CustomerResponseDto>> GetAllCustomer();
        Task<CustomerResponseDto> GetByIdCustomer(Guid id);
        Task<CustomerResponseDto> UpdateCustomer(Guid id, CustomerRequestDto customerRequestDto);
    }
}