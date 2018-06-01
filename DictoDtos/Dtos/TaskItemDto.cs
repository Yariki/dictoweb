using System.Collections.Generic;

namespace DictoInfrasctructure.Dtos
{
    public class TaskItemDto
    {
        public string Origin { get; set; }

        public List<VariantDto> Variants { get; set; }

        public WordDto Word { get; set; }
    }
}