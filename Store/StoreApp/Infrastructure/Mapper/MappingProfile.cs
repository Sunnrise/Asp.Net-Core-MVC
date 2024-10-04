using AutoMapper;
using Entities.DTOs;
using Entities.Models;

namespace StoreApp.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDTO_ForInsertion,Product>();
            CreateMap<ProductDTO_ForUpdate,Product>().ReverseMap();
        }
    }
}