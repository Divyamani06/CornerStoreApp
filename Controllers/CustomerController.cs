using AutoMapper;
using CornerStore.API.Dtos.RequestDtos;
using CornerStore.API.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CornerStore.API.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomersService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomersService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var customer = await _customerService.GetAllCustomer();
            if (customer.Count() == 0)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDCustomer(Guid id)
        {
            var customer = await _customerService.GetByIdCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, CustomerRequestDto customer)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var reponse = await _customerService.UpdateCustomer(id, customer);

            return Ok(reponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var result = await _customerService.DeteleCustomer(id);
            return Ok(result);
        }

    }
}
