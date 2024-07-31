using AutoMapper;
using CornerStore.API.Dtos.RequestDtos;
using CornerStore.API.Services.Interfacese;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CornerStore.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var Category = await _categoryService.GetAllCategorys();
            if (Category.Count() == 0)
            {
                return NotFound();
            }
            return Ok(Category);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDCategory(Guid id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreatCategory(CategoryRequestDto category)
        {
            var categoryDetails = await _categoryService.CreateCategory(category);
            return Ok(categoryDetails);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, CategoryRequestDto category)
        {
            if (id == null)
            {
                return BadRequest();
            }
            await _categoryService.UpdateCategory(id, category);

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var result = await _categoryService.DeleteCategory(id);
            return Ok(result);
        }
    }
}
