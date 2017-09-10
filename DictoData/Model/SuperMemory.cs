using System;
using DictoData.Core;

namespace DictoData.Model
{
    public class SuperMemory : CoreEntity
    {
        public int Repetition { get; set; }

        public int RepetitionInterval { get; set; }

        public double EF { get; set; }

        public DateTime LastRepetition { get; set; }

        public DateTime NextRepetition { get; set; }

        public int WordId { get; set; }
        
    }
}