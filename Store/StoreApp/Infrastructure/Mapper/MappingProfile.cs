using AutoMapper;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace StoreApp.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDTO_ForInsertion,Product>();
            CreateMap<ProductDTO_ForUpdate,Product>().ReverseMap();
            CreateMap<UserDTO_ForCreation,IdentityUser>();
            CreateMap<UserDTO_ForUpdate,IdentityUser>().ReverseMap();
        }
    }
}