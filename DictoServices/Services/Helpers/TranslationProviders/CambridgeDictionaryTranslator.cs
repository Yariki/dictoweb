using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DictoInfrasctructure.Enums;
using DictoServices.Base;
using DictoServices.Data;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;

namespace DictoServices.Services.Helpers
{
    public class CambridgeDictionaryTranslator : CoreTranslator
    {
        readonly string DICTIONARY_URL = "https://dictionary.cambridge.org/dictionary/english/{0}";

        public CambridgeDictionaryTranslator(ILogger logger, Language source, Language target, string query) : base(logger, source, target, query)
        {
        }

        public  override async Task<TranslateRequestResult> Request()
        {
            try
            {
                var web = new HtmlWeb();
                var doc = await web.LoadFromWebAsync(string.Format(DICTIONARY_URL,Query));
                var defs = doc.DocumentNode.SelectNodes("//b[contains(@class, 'def')]");
                var result = new TranslateRequestResult() { Original = Query };
                result.Translate = new Dictionary<string, string[]>();
                result.Translate.Add("", defs.Take(5).Select(n => n.InnerText.Replace('\n', ' ').Trim()).ToArray());
                return result;
            }
            catch (Exception e)
            {
                Log(e.ToString());
            }

            return null;
        }
    }
}