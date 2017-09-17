using System;
using System.Threading.Tasks;
using DictoData.Model;
using DictoInfrasctructure.Core;
using DictoInfrasctructure.Dtos;
using DictoServices.Data;
using DictoServices.Interfaces;
using DictoServices.Services.Helpers;
using Microsoft.Extensions.Logging;
using SQLitePCL;

namespace DictoServices.Services
{
    public class TranslationService : CoreService, ITranslationService
    {   
        public TranslationService(ILogger<TranslationService> logger) : base(logger)
        {
        }

        public async Task<GoogleRequestResult> Translate(TranslateQueryDto translateData)
        {
            var translator =   new BingTranslator(GetLogger(), GetLanguage(translateData.SourceLanguage), GetLanguage(translateData.TargetLanguage), translateData.Original);
                //new GoogleTranslator(GetLogger(),GetLanguage(translateData.SourceLanguage),GetLanguage(translateData.TargetLanguage),translateData.Original);
            var result = await translator.Request();
            return result;
        }
        
        private Language GetLanguage(string value)
        {
            return (Language)Enum.Parse(typeof(Language), value, true);
        }

        
    }
}