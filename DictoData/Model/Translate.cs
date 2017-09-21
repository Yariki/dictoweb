using DictoData.Core;
using DictoInfrasctructure.Enums;

namespace DictoData.Model
{
    public class Translate : CoreEntity
    {
        public string Text { get; set; }

        public WordType WordType { get; set; }

        public int WordId { get; set; }

        public Word Word { get; set; }
        
    }
}