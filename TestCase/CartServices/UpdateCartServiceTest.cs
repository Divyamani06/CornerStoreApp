using AutoMapper;
using CornerStore.API.Dtos.RequestDtos;
using CornerStore.API.Dtos.ResponseDtos;
using CornerStore.API.Model;
using CornerStore.API.Repositories.IRepositories;
using CornerStore.API.Services;
using FluentAssertions;
using NSubstitute;

namespace CornerStore_Tests.Services.CartServices
{
    public class UpdateCartServiceTest
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly CartService _sut;
        public UpdateCartServiceTest()
        {
            _cartRepository = Substitute.For<ICartRepository>();
            _mapper = Substitute.For<IMapper>();
            _productRepository = Substitute.For<IProductRepository>();
            _sut = new CartService(_cartRepository, _mapper, _productRepository);
        }

        [Fact]
        public async Task UpdateCart_WhenUserPassedVaild_ReturnSuccess()
        {
            var requestDto = new CartRequestDto
            {
                Quantity = 1,
                ProductId = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
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

            _cartRepository.GetById(Arg.Any<Guid>()).Returns(Task.FromResult(cart));
            _mapper.Map<Cart>(Arg.Any<CartRequestDto>()).Returns(cart);
            _mapper.Map<CartResponseDto>(Arg.Any<Cart>()).Returns(expectedResult);
            _cartRepository.Update(Arg.Any<Cart>()).Returns(Task.FromResult(cart));
            var actualResult = await _sut.UpdateCart(cart.Id, requestDto);
            actualResult.Should().BeEquivalentTo(expectedResult);

        }
    }
}
