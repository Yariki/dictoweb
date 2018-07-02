using System;

namespace DictoInfrasctructure.Dtos
{
    public class DeckDto
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}