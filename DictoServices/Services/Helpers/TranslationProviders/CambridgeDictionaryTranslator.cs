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
    public class CambridgeDictionaryTranslator : CoreTranslator
    {
        private readonly string DICTIONARY_BASE_URL = "https://dictionary.cambridge.org/{0}";
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
                var sounds = doc.DocumentNode.SelectNodes("//span[contains(@class,'audio_play_button')]");
                var result = new TranslateRequestResult() { Original = Query };
                result.Translate = new Dictionary<string, string[]>();
                result.Translate.Add("", defs.Take(5).Select(n => n.InnerText.Replace('\n', ' ').Trim()).ToArray());
                if (sounds.IsNotNull() && sounds.Count > 0)
                {
                    result.UrlSound = string.Format(DICTIONARY_BASE_URL,sounds[0].GetAttributeValue("data-src-mp3",null));
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