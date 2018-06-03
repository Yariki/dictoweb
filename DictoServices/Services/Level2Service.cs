using AutoMapper;
using DictoData.Interfaces;
using DictoInfrasctructure.Enums;
using DictoServices.Interfaces;
using DictoServices.Services.Core;
using Microsoft.Extensions.Logging;

namespace DictoServices.Services
{
    public class Level2Service : CoreLevelService, ISecondLevelService
    {
        public Level2Service(ILogger<Level2Service> logger, IUnitOfWork unitOfWork, IMapper mapper) : base(logger, unitOfWork, mapper)
        {
        }

        protected override LevelType Level => LevelType.Second;
    }
}