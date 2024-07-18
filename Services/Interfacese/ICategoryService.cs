using CornerStore.API.Dtos.RequestDtos;
using CornerStore.API.Dtos.ResponseDtos;

namespace CornerStore.API.Services.Interfacese
{
    public interface ICategoryService
    {
        Task<CategoryResponseDto> CreateCategory(CategoryRequestDto category);
        Task<Guid> DeleteCategory(Guid id);
        Task<List<CategoryResponseDto>> GetAllCategorys();
        Task<CategoryResponseDto> GetCategoryById(Guid id);
        Task<CategoryResponseDto> UpdateCategory(Guid id, CategoryRequestDto category);
    }
}