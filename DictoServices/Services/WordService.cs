using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DictoData.Interfaces;
using DictoData.Model;
using DictoInfrasctructure.Const;
using DictoInfrasctructure.Core;
using DictoInfrasctructure.Dtos;
using DictoInfrasctructure.Enums;
using DictoInfrasctructure.Extensions;
using DictoServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DictoServices.Services
{
    public class WordService : CoreService,IWordService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WordService(ILogger<WordService> logger,IUnitOfWork unitOfWork, IMapper mapper) : base(logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Word>> GetAllWords()
        {
            var listWords = await _unitOfWork.Repository<Word>().Set.Include(w => w.Translates).ToListAsync();
            return listWords;
        }

        public async Task<IEnumerable<Word>> GetWordWithoutDeck()
        {
            var listWords = await _unitOfWork.Repository<Word>().GetFilteredAsync(w => w.DeckId == 0);
            return listWords;
        }
        
        public async Task<IEnumerable<Word>> GetDeckWords(int DeckId)
        {
            var listWords = await _unitOfWork.Repository<Word>().GetFilteredAsync(w => w.DeckId == DeckId);
            return listWords;
        }

        public async Task<WordPaginationResultDto> GetPagedAndFilteredList(WordPaginationDto wordPaginationDto)
        {
            var wordPaginationResultDto = new WordPaginationResultDto();
            IEnumerable<Word> list = null;
            
            if (string.IsNullOrEmpty(wordPaginationDto.Letter))
            {
                list = await _unitOfWork.Repository<Word>().GetFilteredAsync(null,"Deck");
            }
            else
            {
                list = await _unitOfWork.Repository<Word>().GetFilteredAsync(w =>
                    w.Text.StartsWith(wordPaginationDto.Letter, StringComparison.InvariantCultureIgnoreCase),"Deck");
            }
            wordPaginationResultDto.PagesCount = (int)Math.Ceiling((double)list.Count() / (double)GlobalConst.DefaultPageSize);
            wordPaginationResultDto.Words = list.Skip((wordPaginationDto.Page - 1) * wordPaginationDto.PageSize)
                .Take(wordPaginationDto.PageSize).Select(w =>
                {
                    var wordDto = _mapper.Map<WordDto>(w);
                    wordDto.Deck = _mapper.Map<DeckDto>(w.Deck);
                    return wordDto;
                });

            return wordPaginationResultDto;
        }
        
        
        public async void AddNewWord(TranslateResultDto translateResult, string userName)
        {
            var userID = await GetUserId(userName);
            
            var word = new Word(){Text = translateResult.Original,Level = LevelType.First,Phonetic = translateResult.Phonetic,SuperMemory = new SuperMemory(),UserId = userID, Translates = new List<Translate>()};
            foreach (var pair in translateResult.Translate)
            {
                WordType wordType = string.IsNullOrEmpty(pair.Key) ? WordType.None : pair.Key.GetEnumValue<WordType>();

                foreach (var translation in pair.Value)
                {
                    var t = new Translate(){Text = translation,WordType = wordType};
                    word.Translates.Add(t);
                }
            }
            _unitOfWork.Repository<Word>().Insert(word);
            _unitOfWork.SaveChanges();
        }

        public async Task<UserWordsInfoDto> GetUserWordsInfo(string userName)
        {
            var userId = await GetUserId(userName);

            var words = await _unitOfWork.Repository<Word>().GetFilteredAsync(w => w.UserId == userId);
            var wordsInfo = new UserWordsInfoDto()
            {
                Count = words.Count(),
                Level1 = words.Count(w => w.Level == LevelType.First),
                Level2 = words.Count(w => w.Level == LevelType.Second),
                Level3 = words.Count(w => w.Level == LevelType.Third),
                Compleate = words.Count(w => w.Level == LevelType.Compleate)
            };
            return wordsInfo;
        }

       

        public void UpdateWord(WordDto wordDto)
        {
            var word = _mapper.Map<Word>(wordDto);
            _unitOfWork.Repository<Word>().Update(word);
            _unitOfWork.SaveChanges();
        }

        public async void UpdateWordLevel(WordLevelInfoDto wordLevelInfoDto)
        {
            var words = await _unitOfWork.Repository<Word>().GetFilteredAsync(w => w.Id == wordLevelInfoDto.WordId);
            var word = words.FirstOrDefault();
            if (word.IsNull())
            {
                throw new NullReferenceException();
            }

            word.Level = wordLevelInfoDto.Level;
            _unitOfWork.SaveChanges();
        }

        public async void UpdateWordsDesk(DeckWordsDto deckWordsDto)
        {
            var words = await _unitOfWork.Repository<Word>()
                .GetFilteredAsync(w => deckWordsDto.WordIds.Any(dw => dw == w.Id));
            foreach (var word in words)
            {
                word.DeckId = deckWordsDto.DeckId;
            }

            _unitOfWork.SaveChanges();
        }

        private async Task<int> GetUserId(string userName)
        {
            var users = await _unitOfWork.Repository<User>().GetFilteredAsync(user => user.Email == userName);
            if (users == null || !users.Any())
            {
                throw new KeyNotFoundException($"User {userName} wasn't found");
            }

            var userId = users.First().Id;
            return userId;
        }
        
        
        

        
    }
}