using System.Collections.Generic;

namespace DictoInfrasctructure.Dtos
{
    public class MemoryRepeatResultDto
    {
        public MemoryRepeatResultDto()
        {
            NewWords = new List<WordDto>();
            RepeatedWords = new List<WordDto>();
        }

        public IList<WordDto> NewWords { get; set; }
        
        public IList<WordDto> RepeatedWords { get; set; }
    }
}