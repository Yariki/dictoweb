using DictoData.Core;

namespace DictoData.Model
{
    public class Deck : CoreEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

    }
}