using System.Collections.Generic;
using System.Threading.Tasks;
using DictoData.Model;
using DictoInfrasctructure.Dtos;

namespace DictoServices.Interfaces
{
    public interface IWordService
    {
        void AddNewWord(TranslateResultDto translateResult);
        Task<IEnumerable<Word>> GetAllWords();
        Task<UserWordsInfoDto> GetUserWordsInfo(string userName);
        void UpdateWord(WordDto wordDto);
        void UpdateWordLevel(WordLevelInfoDto wordLevelInfoDto);
    }
}