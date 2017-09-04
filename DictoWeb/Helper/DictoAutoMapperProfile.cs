using AutoMapper;
using DictoData.Model;
using DictoDtos.Dtos;

namespace DictoWeb.Helper
{
    public class DictoAutoMapperProfile : Profile
    {
        public DictoAutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();
        }
    }
}