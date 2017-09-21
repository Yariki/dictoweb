using System;
using DictoInfrasctructure.Enums;

namespace DictoInfrasctructure.Dtos
{
    public class TranslateEntityDto
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public string Text { get; set; }
        public WordType WordType { get; set; }

        public int WordId { get; set; }

    }
}