using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bing;
using DictoData.Model;
using DictoInfrasctructure.Enums;
using DictoServices.Base;
using DictoServices.Data;
using Microsoft.Extensions.Logging;

namespace DictoServices.Services.Helpers
{
    public class BingTranslator : CoreTranslator
    {
        const string APP_ID = "C00D3DB6B8961C311C2E561ED6793D03A2CE81B1";


        public BingTranslator(ILogger logger, Language source, Language target, string query)
        :base(logger,source,target,query)
        {
        }
        
        public override async Task<TranslateRequestResult> Request()
        {
            var client = new Bing.LanguageServiceClient();
            var response =  await  client.GetTranslationsAsync(APP_ID, Query, Source.ToString(), Target.ToString(), 5,
                new TranslateOptions());
            
            var result = new TranslateRequestResult(){Original = Query}; 
            result.Translate = new Dictionary<string, string[]>();
            result.Translate.Add("",response.Translations.Select(m => m.TranslatedText).ToArray());

            return result;
        }
    }
}