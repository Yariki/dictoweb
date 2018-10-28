using DictoData.Core;

namespace DictoData.Model
{
    public class Example : CoreEntity
    {
        public string Text { get; set; }

        public int WordId { get; set; }

        public Word Word { get; set; }
    }
}