using System;
using DictoData.Core;

namespace DictoData.Model
{
    public class Setting : CoreEntity
    {
        public int CountNew { get; set; }

        public int Minute { get; set; }

        public DateTime LastUsedSM2 { get; set; }

        public int UserId { get; set; }
        
    }
}