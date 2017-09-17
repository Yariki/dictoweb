using System.Data.Common;
using DictoData.Model;
using DictoInfrasctructure.Const;
using DictoServices.Base;
using Microsoft.Extensions.Logging;


namespace DictoServices.Services.Helpers
{
    public static class TranslationFactory    
    {
        public static CoreTranslator GetProvider(ILogger logger, Language source, Language target, string query,
            string provider = "google")
        {
            CoreTranslator result = null;
            switch (provider)
            {
                    case GlobalConst.GoogleTranslator:
                        result = new GoogleTranslator(logger,source,target,query);
                        break;
                    case GlobalConst.BingTranslator:
                        result = new BingTranslator(logger,source,target,query);
                        break;
            }
            return result;
        }
    }
}