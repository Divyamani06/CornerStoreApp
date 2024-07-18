using AutoMapper;
using CornerStore.API.Dtos.RequestDtos;
using CornerStore.API.Dtos.ResponseDtos;
using CornerStore.API.Model;
using CornerStore.API.Repositories.Interfacese;
using CornerStore.API.Services.Interfacese;

namespace CornerStore.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryResponseDto> CreateCategory(CategoryRequestDto category)
        {
            var response = _mapper.Map<Category>(category);
            var result = await _categoryRepository.AddAsync(response);
            return _mapper.Map<CategoryResponseDto>(result);
        }

        public async Task<List<CategoryResponseDto>> GetAllCategorys()
        {
            var details = await _categoryRepository.GetAll();
            var response = _mapper.Map<List<CategoryResponseDto>>(details);
            return response;
        }

        public async Task<CategoryResponseDto> GetCategoryById(Guid id)
        {
            var Category = await _categoryRepository.GetById(id);
            var result = _mapper.Map<Category>(Category);
            return _mapper.Map<CategoryResponseDto>(result);
        }

        public async Task<CategoryResponseDto> UpdateCategory(Guid id, CategoryRequestDto category)
        {
            var existingCart = await _categoryRepository.GetById(id);
            var response = _mapper.Map<Category>(existingCart);
            var result = await _categoryRepository.Update(existingCart);
            return _mapper.Map<CategoryResponseDto>(result);
        }

        public async Task<Guid> DeleteCategory(Guid id)
        {
            var reuslt =await _categoryRepository.Delete(id);
            return reuslt.Id;
        }
    }
}
