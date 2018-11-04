using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DictoServices.Base;
using DictoServices.Data;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;

namespace DictoServices.Services.Helpers.ExampleProviders
{
    public class OxfordExamplesProvider  : CoreExamplesProvider
    {
        private readonly string DICTIONARY_URL = "https://en.oxforddictionaries.com/definition/{0}";
        private string openBr = "&lsquo;";
        private string closeBr = "&rsquo;";

        public OxfordExamplesProvider(string original, ILogger logger) : base(original, logger)
        {
        }

        public override async Task<ExamplesRequestResult> GetExamples()
        {
            try
            {
                var web = new HtmlWeb();
                var doc = await web.LoadFromWebAsync(string.Format(DICTIONARY_URL, Original));
                var examples = doc.DocumentNode.SelectNodes("//div[contains(@class, 'exg')]");
                var result = new ExamplesRequestResult
                {
                    Examples = examples.Take(5).Select(n => Regex.Replace(n.InnerText.Trim(), "&lsquo;|&rsquo;","")).ToList()
                };

                return result;
            }
            catch (Exception e)
            {
                Log(LogLevel.Error,e.ToString());
            }

            return null;
        }
    }
}