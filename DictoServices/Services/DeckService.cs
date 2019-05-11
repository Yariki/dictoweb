using System.Collections.Generic;
using System.Linq;
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

        public override async Task<IEnumerable<DeckDto>> Get(string userName)
        {
            var result = GetUser(userName).Result;
            if (result.IsNull())
            {
                throw new  NotFoundItemException($"Couldn't find user with name '{userName}'");
            }
            
            var list = await UnitOfWork.Repository<Deck>().GetFilteredAsync(d => d.UserId == result.Id);

            return list.Select(d => Mapper.Map<DeckDto>(d)).ToList();
        }

        protected override void UpdateItem(User user, Deck model, DeckDto transportModel)
        {
            if (user != null && model != null)
            {
                model.UserId = user.Id;
            }
        }
    }
}