using AutoMapper;
using CornerStore.API.Dtos.RequestDtos;
using CornerStore.API.Dtos.ResponseDtos;
using CornerStore.API.Model;
using CornerStore.API.Repositories.Interfacese;
using CornerStore.API.Services;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace CornerStore_Tests.Services.CategoryServices
{
    public class CreatCategoryServiceTest
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryService _sut;
        public CreatCategoryServiceTest()
        {
            _categoryRepository = Substitute.For<ICategoryRepository>();
            _mapper = Substitute.For<IMapper>();
            _sut = new CategoryService(_categoryRepository,_mapper);
        }

        [Fact]
        public async Task CreateCategory_WhenUserPassedNull_ReturnSuccess()
        {
            

            _mapper.Map<CategoryRequestDto>(Arg.Any<Category>()).ReturnsNull();
            _categoryRepository.AddAsync(Arg.Any<Category>()).ReturnsNull();
            var actaulResutl = await _sut.CreateCategory(null);

            actaulResutl.Should().ReturnsNull();
        }

        [Fact]
        public async Task CreateCategory_WhenUserPassedValid_ReturnSuccess()
        {
            var categoryRequestDto = new CategoryRequestDto
            {
                Name = "name"
            };

            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = "name"
            };
            var expectedResult = new CategoryResponseDto
            {
                Id = category.Id,
                Name = "name"
            };

            _mapper.Map<Category>(categoryRequestDto).Returns(category);
            _categoryRepository.AddAsync(Arg.Any<Category>()).Returns(Task.FromResult(category));
            _mapper.Map<CategoryResponseDto>(category).Returns(expectedResult);


            var actualResult = await _sut.CreateCategory(categoryRequestDto);

            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task CreateCategory_WhenUserPassedNul_ReturnFaild()
        {


            _mapper.Map<Category>(Arg.Any<CartRequestDto>()).ReturnsNull();
            _categoryRepository.AddAsync(Arg.Any<Category>()).ReturnsNull();
            _mapper.Map<CategoryResponseDto>(Arg.Any<Category>()).ReturnsNull();


            var actualResult = await _sut.CreateCategory(null);

            actualResult.Should().ReturnsNull();
        }
    }
}
