using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DictoData.Interfaces;
using DictoData.Model;
using DictoInfrasctructure.Core;
using DictoInfrasctructure.Dtos;
using DictoInfrasctructure.Enums;
using DictoServices.Interfaces;
using DictoServices.Services.Core;
using Microsoft.AspNetCore.Rewrite.Internal.PatternSegments;
using Microsoft.Extensions.Logging;

namespace DictoServices.Services
{
    public class Level1Service : CoreLevelService, IFirstLevelService
    {
        public Level1Service(ILogger<Level1Service> logger, IUnitOfWork unitOfWork, IMapper mapper) : base(logger, unitOfWork, mapper)
        {
        }

        protected override LevelType Level => LevelType.First;
    }
}