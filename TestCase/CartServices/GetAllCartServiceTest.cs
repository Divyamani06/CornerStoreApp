using AutoMapper;
using CornerStore.API.Dtos.ResponseDtos;
using CornerStore.API.Model;
using CornerStore.API.Repositories.IRepositories;
using CornerStore.API.Services;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace CornerStore_Tests.Services.CartServices
{
    public class GetAllCartServiceTest
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly CartService _sut;
        public GetAllCartServiceTest()
        {
            _cartRepository = Substitute.For<ICartRepository>();
            _mapper = Substitute.For<IMapper>();
            _productRepository = Substitute.For<IProductRepository>();
            _sut = new CartService(_cartRepository, _mapper, _productRepository);
        }

        [Fact]
        public async Task GetAllCart_WhenUserPassedVaild_ReturnSuccess()
        {
            var cart = new List<Cart>
            {
               new() {
                    Id = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                Quantity = 10
               },
               new()
               {
                    Id = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                Quantity = 10
               },

                new()
                {
                     Id = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                Quantity = 10
                }

            };
            var responseDto = new List<CartResponseDto>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                Quantity =10
                },
                new(){
                    Id = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                Quantity =10
                },
                new()
                {
                    Id = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                Quantity =10
                }
            };
            _cartRepository.GetAll().Returns(Task.FromResult(cart));
            _mapper.Map<List<CartResponseDto>>(Arg.Any<List<Cart>>()).Returns(responseDto);
            var actualResut =await _sut.GetAllCart();
            actualResut.Should().BeEquivalentTo(responseDto);
        }

        [Fact]
        public async Task GetAllCart_WhenUserPassedNull_ReturnFailed()
        {

            _cartRepository.GetAll().ReturnsNull();
            _mapper.Map<List<CartResponseDto>>(Arg.Any<List<Cart>>()).ReturnsNull();
            var actualResut = await _sut.GetAllCart();
            actualResut.Should().ReturnsNull();
        }
    }
}
