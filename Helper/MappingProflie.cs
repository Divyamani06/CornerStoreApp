using AutoMapper;
using CornerStore.API.Dtos.RequestDtos;
using CornerStore.API.Dtos.ResponseDtos;
using CornerStore.API.Model;
using CornerStore.API.Models;

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
            CreateMap<OrderRequestDto, Order>().ReverseMap();
            CreateMap<OrderResponseDto, Order>().ReverseMap();
            CreateMap<ShipmentRequestDto, Shipment>().ReverseMap();
            CreateMap<ShipmentResponseDto, Shipment>().ReverseMap();
            CreateMap<RegisterModel, Customer>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(source => source.FirstName + source.LastName))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(source => source.Password))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(source => source.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(source => source.LastName))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(source => source.Address))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(source => source.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(source => source.PhoneNumber));
        }
    }
}
