using AutoMapper;
using DictoData.Model;
using DictoInfrasctructure.Dtos;
using DictoServices.Data;

namespace DictoWeb.Helper
{
    public class DictoAutoMapperProfile : Profile
    {
        public DictoAutoMapperProfile()
        {
            CreateMap<User, UserDto>().ForMember(u => u.Password, opt => opt.Ignore()).ForSourceMember(u => u.Password, opt => opt.Ignore());
            CreateMap<UserDto, User>();
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();
            CreateMap<TranslateRequestResult, TranslateResultDto>();
            CreateMap<Translate, TranslateDto>();
            CreateMap<TranslateDto, Translate>();
            CreateMap<Word, WordDto>();
            CreateMap<WordDto, Word>();
            CreateMap<DeckDto, Deck>();
            CreateMap<Deck, DeckDto>();
            CreateMap<Example, ExampleDto>();
            CreateMap<ExampleDto, Example>();
        }
    }
}