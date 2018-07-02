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
            CreateMap<User, UserDto>();
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
        }
    }
}