using System.Collections.Generic;
using DictoData.Core;
using DictoInfrasctructure.Enums;

namespace DictoData.Model
{
    public class Word : CoreEntity
    {

        public Word()
        {
        }
        
        public string Text { get; set; }

        public LevelType Level { get; set; }

        public string Phonetic { get; set; }
        
        public SuperMemory SuperMemory { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public virtual List<Translate> Translates { get; set; }

        public virtual List<Example> Examples { get; set; }

        public int? DeckId { get; set; }

        public Deck Deck { get; set; }
        
    }
}