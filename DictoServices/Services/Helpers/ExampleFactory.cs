using DictoInfrasctructure.Const;
using DictoServices.Base;
using DictoServices.Services.Helpers.ExampleProviders;
using Microsoft.Extensions.Logging;

namespace DictoServices.Services.Helpers
{
    public static class ExampleFactory
    {
        public static CoreExamplesProvider GetProvider(string original, string provider, ILogger logger)
        {
            CoreExamplesProvider examplesProvider = null;
            switch (provider)
            {
                case GlobalConst.CambridgeTranslator:
                    examplesProvider = new CambridgeExamplesProvider(original,logger);
                    break;
                case GlobalConst.OxfordTranslator:
                    examplesProvider = new OxfordExamplesProvider(original,logger);
                    break;
            }
            return examplesProvider;
        }
    }
}