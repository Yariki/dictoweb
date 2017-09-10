using DictoData.Core;

namespace DictoData.Model
{
    public class Transcription : CoreEntity
    {
        public string Original { get; set; }

        public string Phonetic { get; set; }
    }
}