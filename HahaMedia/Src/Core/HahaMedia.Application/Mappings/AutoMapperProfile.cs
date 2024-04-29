using AutoMapper;
using HahaMedia.Domain.Entities;
using HahaMedia.Domain.Products.Dtos;

namespace HahaMedia.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
