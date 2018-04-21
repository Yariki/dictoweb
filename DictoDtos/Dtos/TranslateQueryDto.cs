using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DictoInfrasctructure.Dtos
{
    public class TranslateQueryDto
    {
        
        [Required]
        public string Original { get; set; }

        [Required]
        [DefaultValue("en")]
        public string SourceLanguage { get; set; }

        [Required]
        [DefaultValue("uk")]
        public string TargetLanguage { get; set; }
        
        [Required]
        [DefaultValue("google")]
        public string Provider { get; set; }
        
    }
}