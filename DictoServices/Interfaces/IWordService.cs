using DictoInfrasctructure.Dtos;

namespace DictoServices.Interfaces
{
    public interface IWordService
    {
        void AddNewWord(TranslateDto translate);
    }
}