using AutoMapper;
using ProductsManagement.Domain.DTOs;
using ProductsManagement.Domain.Entities;

namespace ProductsManagement.Domain.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}
