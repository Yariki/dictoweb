using System.Collections.Generic;

namespace DictoInfrasctructure.Dtos
{
    public class WordPaginationResultDto
    {
        public int PagesCount { get; set; }

        public IEnumerable<WordDto> Words { get; set; }
    }
}