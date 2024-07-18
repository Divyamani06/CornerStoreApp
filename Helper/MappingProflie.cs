using AutoMapper;
using CornerStore.API.Dtos.RequestDtos;
using CornerStore.API.Dtos.ResponseDtos;
using CornerStore.API.Model;

namespace CornerStore.API.Helper
{
    public class MappingProflie : Profile
    {
        public MappingProflie()
        {
            CreateMap<CustomerRequestDto, Customer>().ReverseMap();
            CreateMap<CustomerResponseDto, Customer>().ReverseMap();
            CreateMap<CartRequestDto, Cart>().ReverseMap();
            CreateMap<CartResponseDto, Cart>().ReverseMap();
            CreateMap<ProductRequestDto, Product>().ReverseMap();
            CreateMap<ProductResponseDto, Product>().ReverseMap();
            CreateMap<CategoryRequestDto, Category>().ReverseMap();
            CreateMap<CategoryResponseDto, Category>().ReverseMap();
        }
    }
}
