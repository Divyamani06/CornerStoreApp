using AutoMapper;
using CornerStore.API.Dtos.RequestDtos;
using CornerStore.API.Dtos.ResponseDtos;
using CornerStore.API.Model;
using CornerStore.API.Repositories.IRepositories;
using CornerStore.API.Services.IServices;

namespace CornerStore.API.Services
{
    public class CustomerService : ICustomersService
    {
        private readonly ICustomersRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomersRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerResponseDto> CreatCustomer(CustomerRequestDto customerDto)
        {
            var password = _customerRepository.EncryptPassword(customerDto.Password);
            var customerDetails = new CustomerRequestDto
            {
                Password = password,
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Email = customerDto.Email,
                Address = customerDto.Address,
                PhoneNumber = customerDto.PhoneNumber
            };
            var customer = _mapper.Map<Customer>(customerDetails);
            var response = await _customerRepository.AddAsync(customer);

            return _mapper.Map<CustomerResponseDto>(response);
        }

        public async Task<List<CustomerResponseDto>> GetAllCustomer()
        {
            var details = await _customerRepository.GetAll();

            var result = _mapper.Map<List<Customer>>(details);
            return _mapper.Map<List<CustomerResponseDto>>(result);
        }

        public async Task<CustomerResponseDto> GetByIdCustomer(Guid id)
        {
            var customer = await _customerRepository.GetById(id);
            var result = _mapper.Map<Customer>(customer);
            return _mapper.Map<CustomerResponseDto>(result);
        }

        public async Task<CustomerResponseDto> UpdateCustomer(Guid id, CustomerRequestDto customerRequestDto)
        {
            var existingCustomer = await _customerRepository.GetById(id);
            var response = _mapper.Map<Customer>(existingCustomer);
            var result =await _customerRepository.Update(existingCustomer);
            return _mapper.Map<CustomerResponseDto>(result);
        }

        public async Task<Guid> DeteleCustomer(Guid id)
        {
           var result = await _customerRepository.Delete(id);
            return result.Id;
        }

        public async Task<bool> SignIn(string email, string password)
        {
            return await _customerRepository.SignIn(email, password);
        }
    }
}
