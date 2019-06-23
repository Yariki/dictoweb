using System.Collections.Generic;

namespace DictoInfrasctructure.Dtos
{
    public class MemoryRepeatResultDto
    {
        public IList<WordDto> NewWords { get; set; }
        
        public IList<WordDto> RepeatedWords { get; set; }
    }
}