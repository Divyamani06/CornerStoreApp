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
    public class GetByIdCartServiceTest
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly CartService _sut;
        public GetByIdCartServiceTest()
        {
            _cartRepository = Substitute.For<ICartRepository>();
            _mapper = Substitute.For<IMapper>();
            _productRepository = Substitute.For<IProductRepository>();
            _sut = new CartService(_cartRepository, _mapper, _productRepository);
        }

        [Fact]
        public async Task GetByIdCartWhenUserPassedVaild_ReturnsSuccess()
        {
            var cart = new Cart
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                Quantity = 10
            };
            var expectedResult = new CartResponseDto
            {
                Id = cart.Id,
                CustomerId = cart.CustomerId,
                ProductId = cart.ProductId,
                Quantity = cart.Quantity,
            };

            _cartRepository.GetById(Arg.Any<Guid>()).Returns(Task.FromResult(cart));
            _mapper.Map<CartResponseDto>(Arg.Any<Cart>()).Returns(expectedResult);
            var actualResult = await _sut.GetByIdCart(cart.Id);
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GetByIdCartWhenUserPassedNull_ReturnsFaild()
        {

            var cart = new Cart
            {
                Id = Guid.Empty,
            };
            _cartRepository.GetById(Arg.Any<Guid>()).ReturnsNull();
            _mapper.Map<CartResponseDto>(Arg.Any<Cart>()).ReturnsNull();
            var actualResult = await _sut.GetByIdCart(cart.Id);
            actualResult.Should().BeNull();
        }
    }
}
