﻿using AutoMapper;
using CornerStore.API.Dtos.RequestDtos;
using CornerStore.API.Dtos.ResponseDtos;
using CornerStore.API.Model;
using CornerStore.API.Repositories;
using CornerStore.API.Repositories.IRepositories;
using CornerStore.API.Services.IServices;

namespace CornerStore.API.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly ICustomersRepository _customersRepository;
        private readonly IProductRepository _productRepository;

        public CartService(ICartRepository cartRepository, IMapper mapper,IProductRepository productRepository,ICustomersRepository customersRepository)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
            _productRepository = productRepository;
            _customersRepository = customersRepository;
        }

        public async Task<CartResponseDto> CreatCart(CartRequestDto cartDto)
        {
            var cusId = _customersRepository.GetAll().Result.First().Id;
            var proId = _productRepository.GetAll().Result.First().Id;
            var detail = new CartRequestDto
            {
                CustomerId = cusId,
                Quantity = cartDto.Quantity,
                ProductId = proId
            };
            var cart = _mapper.Map<Cart>(detail);
            var response = await _cartRepository.AddAsync(cart);

            return _mapper.Map<CartResponseDto>(response);
        }

        public async Task<List<CartResponseDto>> GetAllCart()
        {
            var details = await _cartRepository.GetAll();
            var getid =details.First().Id;
            var customerId = await _cartRepository.GetCartByCustomer(getid);
           
            var result = _mapper.Map<List<Cart>>(details);
            return _mapper.Map<List<CartResponseDto>>(result);
        }

        public async Task<CartResponseDto> GetByIdCart(Guid id)
        {
            var cart = await _cartRepository.GetById(id);
            var result = _mapper.Map<Cart>(cart);
            return _mapper.Map<CartResponseDto>(result);
        }

        public async Task<CartResponseDto> UpdateCart(Guid id, CartRequestDto CartRequestDto)
        {
            var existingCart = await _cartRepository.GetById(id);
            var detail = new Cart
            {
                CustomerId = existingCart.CustomerId,
                Quantity = existingCart.Quantity,
            };
            var response = _mapper.Map<Cart>(detail);
            var result = await _cartRepository.Update(existingCart);
            return _mapper.Map<CartResponseDto>(result);
        }

        public async Task<Guid> DeteleCart(Guid id)
        {
            var result = await _cartRepository.Delete(id);
            return result.Id;
        }
    }
}
