using System.Linq;
using AutoMapper;
using DictoData.Interfaces;
using DictoData.Model;
using DictoInfrasctructure.Enums;
using DictoInfrasctructure.Extensions;
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

        protected override string GetOriginalText(Word word)
        {
            return word.IsNotNull() && word.Translates.IsNotNull() && word.Translates.Any() ? string.Join(", ", word.Translates.Select(t => t.Text)) : string.Empty;
        }

        protected override string GetVariantText(Word word)
        {
            return word.IsNotNull() ? word.Text : string.Empty;
        }
    }
}