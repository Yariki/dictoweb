using System.ComponentModel.DataAnnotations;

namespace DictoInfrasctructure.Dtos
{
    public class TranslateQueryDto
    {
        
        [Required]
        public string Original { get; set; }

        [Required]
        public string SourceLanguage { get; set; }

        [Required]
        public string TargetLanguage { get; set; }
        
        [Required]
        public string Provider { get; set; }
        
    }
}