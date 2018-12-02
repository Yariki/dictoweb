using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DictoInfrasctructure.Enums;
using DictoInfrasctructure.Extensions;
using DictoServices.Base;
using DictoServices.Data;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;

namespace DictoServices.Services.Helpers
{
    public class OxfordDictionaryTranslator : CoreTranslator
    {
        private readonly string DICTIONARY_URL = "https://en.oxforddictionaries.com/definition/{0}";

        public OxfordDictionaryTranslator(ILogger logger, Language source, Language target, string query) : base(logger, source, target, query)
        {
        }

        public override async Task<TranslateRequestResult> Request()
        {
            try
            {
                var web = new HtmlWeb();
                var doc = await web.LoadFromWebAsync(string.Format(DICTIONARY_URL, Query));
                var spans = doc.DocumentNode.SelectNodes("//span[contains(@class, 'ind')]");
                var sounds = doc.DocumentNode.SelectNodes("//audio");
                var result = new TranslateRequestResult() { Original = Query };
                result.Translate = new Dictionary<string, string[]>();
                result.Translate.Add("", spans.Take(5).Select(n => n.InnerText.Replace('\n', ' ').Trim()).ToArray());
                if (sounds.IsNotNull() && sounds.Count > 0)
                {
                    result.UrlSound = sounds[0].GetAttributeValue("src", null);
                }
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