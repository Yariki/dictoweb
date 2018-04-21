using System;
using System.Linq;
using System.Threading.Tasks;
using DictoData.Interfaces;
using DictoData.Model;
using DictoInfrasctructure.Core;
using DictoInfrasctructure.Dtos;
using DictoInfrasctructure.Enums;
using DictoServices.Data;
using DictoServices.Interfaces;
using DictoServices.Services.Helpers;
using Microsoft.Extensions.Logging;
using SQLitePCL;

namespace DictoServices.Services
{
    public class TranslationService : CoreService, ITranslationService
    {
        private IUnitOfWork _unitOfWork;

        public TranslationService(IUnitOfWork unitOfWork, ILogger<TranslationService> logger) : base(logger)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TranslateRequestResult> Translate(TranslateQueryDto translateData)
        {
            var translator =  TranslationFactory.GetProvider(GetLogger(), GetLanguage(translateData.SourceLanguage), GetLanguage(translateData.TargetLanguage), translateData.Original,translateData.Provider);
            var result = await translator.Request();

            result.IsExisting = (await _unitOfWork.Repository<Word>().GetFilteredAsync(w => w.Text == translateData.Original)).Any();

            return result;
        }
        
        private Language GetLanguage(string value)
        {
            return (Language)Enum.Parse(typeof(Language), value, true);
        }

        
    }
}