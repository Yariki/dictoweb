using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DictoData.Interfaces;
using DictoData.Model;
using DictoInfrasctructure.Core;
using DictoInfrasctructure.Dtos;
using DictoInfrasctructure.Exceptions;
using DictoInfrasctructure.Extensions;
using DictoServices.Interfaces;
using DictoServices.Services.Core;
using Microsoft.Extensions.Logging;

namespace DictoServices.Services
{
    public class DeckService : CoreCrudService<Deck,DeckDto>, IDeckService
    {
        public DeckService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeckService> logger) : base(unitOfWork, mapper, logger)
        {
        }

        public override async Task<IEnumerable<Deck>> Get(string userName)
        {
            var user = GetUser(userName);
            if (user.IsNull())
            {
                throw new  NotFoundItemException($"Couldn't find user with name '{userName}'");
            }

            var list = await UnitOfWork.Repository<Deck>().GetFilteredAsync(d => d.UserId == user.Id);

            return list;
        }
    }
}