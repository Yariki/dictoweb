using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DictoServices.Base;
using DictoServices.Data;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;

namespace DictoServices.Services.Helpers.ExampleProviders
{
    public class CambridgeExamplesProvider : CoreExamplesProvider
    {
        readonly string DICTIONARY_URL = "https://dictionary.cambridge.org/dictionary/english/{0}";

        public CambridgeExamplesProvider(string original, ILogger logger) : base(original,logger)
        {
        }

        public override async Task<ExamplesRequestResult> GetExamples()
        {
            try
            {
                var web = new HtmlWeb();
                var doc = await web.LoadFromWebAsync(string.Format(DICTIONARY_URL, Original));
                var defs = doc.DocumentNode.SelectNodes("//div[contains(@class, 'examp dexamp')]");
                var result = new ExamplesRequestResult();
                result.Examples = defs.Take(5).Select(n => n.InnerText.Trim()).ToList();
                return result;
            }
            catch (Exception e)
            {
                Log(LogLevel.Error, e.ToString());
            }

            return null;
        }
    }
}