using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DictoInfrasctructure.Dtos
{
    public class TranslateDto
    {
        public TranslateDto()
        {
            IsExisting = false;
        }

        [Required]
        public string Original { get; set; }

        [Required]
        public Dictionary<string,string[]> Translate { get; set; }

        public string Phonetic { get; set; }
        
        public string UrlSound { get; set; }

        public string Encoding { get; set; }

        public bool IsExisting { get; set; }

    }
}