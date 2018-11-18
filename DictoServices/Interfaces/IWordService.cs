using System.Collections.Generic;
using System.Threading.Tasks;
using DictoData.Model;
using DictoInfrasctructure.Dtos;

namespace DictoServices.Interfaces
{
    public interface IWordService
    {
        Task<Word> GetWord(int id);
        Task<int> AddNewWord(TranslateResultDto translateResult, string userName);
        Task<IEnumerable<Word>> GetAllWords();
        Task<UserWordsInfoDto> GetUserWordsInfo(string userName);
        void UpdateWord(WordDto wordDto);
        Task<int> UpdateWordLevel(WordLevelInfoDto wordLevelInfoDto);
        Task<IEnumerable<Word>> GetWordWithoutDeck();
        Task<IEnumerable<Word>> GetDeckWords(int DeckId);
        Task<int> UpdateWordsDesk(DeckWordsDto deckWordsDto);
        Task<WordPaginationResultDto> GetPagedAndFilteredList(WordPaginationDto wordPaginationDto);
    }
}