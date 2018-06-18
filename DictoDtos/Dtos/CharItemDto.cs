using System.Collections.Generic;

namespace DictoInfrasctructure.Dtos
{
    public class CharItemDto
    {
        public CharItemDto(char c, List<int> order, bool show)
        {
            Char = c;
            Order = order;
            Show = show;
        }

        public char Char { get; private set; }

        public List<int> Order { get; private set; }

        public int CurrentOrder { get; set; }

        public bool Show { get; set; }

        public bool IsError { get; set; }

        public bool Catch { get; set; }


        public static CharItemDto Copy(CharItemDto source)
        {
            var copy = new CharItemDto(source.Char,source.Order,source.Show);
            return copy;
        }

    }
}