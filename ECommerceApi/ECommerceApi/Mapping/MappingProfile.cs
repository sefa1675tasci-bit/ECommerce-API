using AutoMapper;
using ECommerceApi.DTOs;
using ECommerceApi.Entities;

namespace ECommerceApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(
                    dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.Category!.Name));

            CreateMap<CreateProductDto, Product>();

            CreateMap<UpdateProductDto, Product>();

            CreateMap<Category, CategoryDto>();

            CreateMap<CreateCategoryDto, Category>();

            CreateMap<UpdateCategoryDto, Category>();
        }
    }
}