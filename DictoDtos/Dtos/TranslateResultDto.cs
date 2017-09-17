using System.Collections.Generic;

namespace DictoInfrasctructure.Dtos
{
    public class TranslateDto
    {
        public TranslateDto()
        {
            
        }

        public string Original { get; set; }

        public Dictionary<string,string[]> Translate { get; set; }

        public string Phonetic { get; set; }

        public string UrlSound { get; set; }

        public string Encoding { get; set; }
    }
}