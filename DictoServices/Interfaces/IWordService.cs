using System.Collections.Generic;
using System.Threading.Tasks;
using DictoData.Model;
using DictoInfrasctructure.Dtos;

namespace DictoServices.Interfaces
{
    public interface IWordService
    {
        void AddNewWord(TranslateResultDto translateResult, string userName);
        Task<IEnumerable<Word>> GetAllWords();
        Task<UserWordsInfoDto> GetUserWordsInfo(string userName);
        void UpdateWord(WordDto wordDto);
        void UpdateWordLevel(WordLevelInfoDto wordLevelInfoDto);
        Task<IEnumerable<Word>> GetWordWithoutDeck();
        Task<IEnumerable<Word>> GetDeckWords(int DeckId);
        void UpdateWordsDesk(DeckWordsDto deckWordsDto);
        Task<WordPaginationResultDto> GetPagedAndFilteredList(WordPaginationDto wordPaginationDto);
    }
}