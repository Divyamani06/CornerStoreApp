using AutoMapper;
using CornerStore.API.Dtos.RequestDtos;
using CornerStore.API.Dtos.ResponseDtos;
using CornerStore.API.Model;
using CornerStore.API.Repositories.Interfacese;
using CornerStore.API.Repositories.IRepositories;
using CornerStore.API.Services.IServices;

namespace CornerStore.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ICartRepository _cartRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductService(IProductRepository productRepository,IMapper mapper,ICartRepository cartRepository,ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _cartRepository = cartRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ProductResponseDto> CreateProduct(ProductRequestDto product)
        {
            var response = _mapper.Map<Product>(product);
            var result =await _productRepository.AddAsync(response);
            return _mapper.Map<ProductResponseDto>(result);
        }

        public async Task<List<ProductResponseDto>> GetAllProducts()
        {
            var details = await _productRepository.GetAll();
            //var getCategory = _categoryRepository.GetAll().Result.First().Id;
            //var product = new ProductResponseDto
            //{
            //    CategoryId = getCategory,
               
            //};
            var response = _mapper.Map<List<ProductResponseDto>>(details);           
            return response;
           
        }

        public async Task<ProductResponseDto> GetProductById(Guid id)
        {
            var product = await _productRepository.GetById(id);
            var result = _mapper.Map<Product>(product);
            return _mapper.Map<ProductResponseDto>(result);
        }

        public async Task<ProductResponseDto> UpdateProduct(Guid id, ProductRequestDto product)
        {
            var existingCart = await _productRepository.GetById(id);
            var response = _mapper.Map<Product>(existingCart);
            var result = await _productRepository.Update(existingCart);
            return _mapper.Map<ProductResponseDto>(result);
        }

        public async Task DeleteProduct(Guid id)
        {
            await _productRepository.Delete(id);
        }
    }
}
