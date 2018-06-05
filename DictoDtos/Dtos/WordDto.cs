using System;
using System.Collections.Generic;
using System.Globalization;
using DictoInfrasctructure.Enums;

namespace DictoInfrasctructure.Dtos
{
    public class WordDto
    {
        
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public string Text { get; set; }

        public LevelType Level { get; set; }

        public string Phonetic { get; set; }

        public int UserId { get; set; }
        
        public List<TranslateDto> Translates { get; set; }

    }
}