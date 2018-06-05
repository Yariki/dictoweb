using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DictoData.Interfaces;
using DictoData.Model;
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
        
        public void AddNewWord(TranslateResultDto translateResult)
        {
            var word = new Word(){Text = translateResult.Original,Level = LevelType.First,Phonetic = translateResult.Phonetic,SuperMemory = new SuperMemory(),UserId = 1, Translates = new List<Translate>()};
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
            var users = await _unitOfWork.Repository<User>().GetFilteredAsync(user => user.Email == userName);
            if (users == null || !users.Any())
            {
                throw new KeyNotFoundException($"User {userName} wasn't found");
            }

            var userId = users.First().Id;

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



        
    }
}