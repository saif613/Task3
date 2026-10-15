
using AutoMapper;
using Task3.Application.DTOs;
using Task3.Application.Features.Products.Command.CreateProduct;
using Task3.Domain.Entity;

namespace Task3.Application.Mapping;


public class ProductProfile : Profile
{
    public ProductProfile()
    {
        // CreateProductCommand -> Product
        CreateMap<CreateProductCommand, Product>()
            .ForMember(
                dest => dest.ProductName,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(
                dest => dest.UnitPrice,
                opt => opt.MapFrom(src => src.Price));

        // Product -> ProductResponseDto (record)
        CreateMap<Product, ProductResponseDto>()
            .ForCtorParam(
                "Id",
                opt => opt.MapFrom(src => src.Id))
            .ForCtorParam(
                "Name",
                opt => opt.MapFrom(src => src.ProductName))
            .ForCtorParam(
                "Price",
                opt => opt.MapFrom(src => src.UnitPrice));
    }
}


