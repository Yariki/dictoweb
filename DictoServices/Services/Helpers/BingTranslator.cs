using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bing;
using DictoData.Model;
using DictoServices.Data;
using Microsoft.Extensions.Logging;

namespace DictoServices.Services.Helpers
{
    public class BingTranslator
    {
        private ILogger _logger;

        const string APP_ID = "C00D3DB6B8961C311C2E561ED6793D03A2CE81B1";

        private Language _source;
        private Language _target;
        private string _query;

        public BingTranslator(ILogger logger, Language source, Language target, string query)
        {
            _logger = logger;
            _source = source;
            _target = target;
            _query = query;

        }
        
        public async Task<GoogleRequestResult> Request()
        {
            var client = new Bing.LanguageServiceClient();
            var response =  await  client.GetTranslationsAsync(APP_ID, _query, _source.ToString(), _target.ToString(), 5,
                new TranslateOptions());
            
            var result = new GoogleRequestResult(){Original = _query}; 
            result.Translate = new Dictionary<string, string[]>();
            result.Translate.Add("",response.Translations.Select(m => m.TranslatedText).ToArray());

            return result;
        }
    }
}