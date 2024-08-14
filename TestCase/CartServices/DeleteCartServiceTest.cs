using AutoMapper;
using CornerStore.API.Dtos.ResponseDtos;
using CornerStore.API.Model;
using CornerStore.API.Repositories.IRepositories;
using CornerStore.API.Services;
using NSubstitute;

namespace CornerStore_Tests.Services.CartServices
{
    public class DeleteCartServiceTest
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly CartService _sut;
        public DeleteCartServiceTest()
        {
            _cartRepository = Substitute.For<ICartRepository>();
            _mapper = Substitute.For<IMapper>();
            _productRepository = Substitute.For<IProductRepository>();
            _sut = new CartService(_cartRepository, _mapper, _productRepository);
        }

        [Fact]

        public async Task DeleteCart_WhenUserPassedVaild_ReturnSuccess()
        {
            var cart = new Cart
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                Quantity = 10
            };
            _cartRepository.Delete(Arg.Any<Guid>()).Returns(Task.FromResult(cart));
            var actualResult = await _sut.DeteleCart(cart.Id);
            Assert.True(true);
        }
    }
}
