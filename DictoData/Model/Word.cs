using System.Collections.Generic;
using DictoData.Core;

namespace DictoData.Model
{
    public class Word : CoreEntity
    {
        public string Text { get; set; }

        public LevelType Level { get; set; }

        public string Phonetic { get; set; }
        
        public SuperMemory SuperMemory { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public List<Translate> Translates { get; set; }
        
    }
}