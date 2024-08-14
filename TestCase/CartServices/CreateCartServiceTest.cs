using AutoMapper;
using CornerStore.API.Dtos.RequestDtos;
using CornerStore.API.Dtos.ResponseDtos;
using CornerStore.API.Model;
using CornerStore.API.Repositories.IRepositories;
using CornerStore.API.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace CornerStore_Tests.Services.CartServices
{
    public class CreateCartServiceTest
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly CartService _sut;
        public CreateCartServiceTest()
        {
            _cartRepository = Substitute.For<ICartRepository>();
            _mapper = Substitute.For<IMapper>();
            _productRepository = Substitute.For<IProductRepository>();
            _sut = new CartService(_cartRepository, _mapper, _productRepository);
        }

        [Fact]
        public async Task CreateCart_WhenUserPassedValid_ReturnSuccess()
        {
            var requestDto = new CartRequestDto
            {
                Quantity = 1,
                ProductId = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
            };
            var product = new Product
            {
                Id = requestDto.ProductId,
                Stock = 5
            };
            var cart = new Cart
            {
                Id = Guid.NewGuid(),
                CustomerId = requestDto.CustomerId,
                ProductId = requestDto.ProductId,
                Quantity = requestDto.Quantity,
            };
            var expectedResult = new CartResponseDto
            {
                Id = cart.Id,
                CustomerId = requestDto.CustomerId,
                ProductId = requestDto.ProductId,
                Quantity = requestDto.Quantity,
            };

            _productRepository.GetById(Arg.Any<Guid>()).Returns(product);
            _cartRepository.GetById(Arg.Any<Guid>()).Returns(Task.FromResult(cart));
            _cartRepository.AddAsync(Arg.Any<Cart>()).Returns(Task.FromResult(cart));
            _mapper.Map<CartResponseDto>(Arg.Any<Cart>()).Returns(expectedResult);
            var actualResult = await _sut.CreatCart(requestDto);

            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task CreatCart_WhenUserPassedStockNull_ReturnFaild()
        {
            var requestDto = new CartRequestDto
            {
                Quantity = 1,
                ProductId = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
            };
            var prodcut = new Product
            {
                Id = requestDto.ProductId,
            };
            _productRepository.GetById(Arg.Any<Guid>()).Returns(prodcut);
            var expectedResult = "The quantity requested for Product is out of stock.";
            Func<Task> act = async()=> await _sut.CreatCart(requestDto);
            var excetion = await Assert.ThrowsAsync<Exception>(act);
            excetion.Message.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task CreatCart_WhenUserPassedNullCreateCart_ReturnFaild()
        {
            var requestDto = new CartRequestDto
            {
                Quantity = 0,

            };
            var prodcut = new Product
            {
                Id = requestDto.ProductId,
                Stock = 5
            };

            _productRepository.GetById(Arg.Any<Guid>()).Returns(prodcut);
            _cartRepository.AddAsync(Arg.Any<Cart>()).ReturnsNull();
            _mapper.Map<Cart>(Arg.Any<CartRequestDto>()).ReturnsNull();
            var actualResult = await _sut.CreatCart(requestDto);
            actualResult.Should().ReturnsNull();
        }
    }
}
