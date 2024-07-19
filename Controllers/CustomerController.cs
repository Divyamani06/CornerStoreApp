﻿using AutoMapper;
using CornerStore.API.Dtos.RequestDtos;
using CornerStore.API.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CornerStore.API.Controllers
{
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

        [HttpPost]
        public async Task<IActionResult> CreatCustomer(CustomerRequestDto customer)
        {
            var customerDetails = await _customerService.CreatCustomer(customer);
            return Ok(customerDetails);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, CustomerRequestDto customer)
        {
            if (id != customer.Id)
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

        [HttpPost("{email},{password}")]
        public async Task<IActionResult> SignIn(string email, string password)
        {
            var result = await _customerService.SignIn(email, password);
            if(result == "customer is not found")
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
