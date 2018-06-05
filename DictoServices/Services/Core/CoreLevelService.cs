using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DictoData.Interfaces;
using DictoData.Model;
using DictoInfrasctructure.Core;
using DictoInfrasctructure.Dtos;
using DictoInfrasctructure.Enums;
using Microsoft.Extensions.Logging;

namespace DictoServices.Services.Core
{
    public class CoreLevelService :  CoreService
    {
        private const int MAX_GENERATE_LEVEL_1 = 10;

        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CoreLevelService(ILogger logger, IUnitOfWork unitOfWork, IMapper mapper) : base(logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        protected virtual LevelType Level => LevelType.None;


        public async Task<List<TaskItemDto>> GenerateDataLevelAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException("userName");
            }

            var users = await _unitOfWork.Repository<User>().GetFilteredAsync(user => user.Email == userName);
            if (users == null || !users.Any())
            {
                throw new KeyNotFoundException($"User {userName} wasn't found");
            }
            var userId = users.First().Id;

            var levelList = await _unitOfWork.Repository<Word>().GetFilteredAsync(w => w.Level == Level && w.UserId == userId, "Translates");
            var listWords = levelList.ToList();

            var list = new List<TaskItemDto>();
            var count = listWords.Count;
            var rand = new Random(count);

            for (int i = 0; i < MAX_GENERATE_LEVEL_1; i++)
            {
                var newRand = rand.Next(count);
                var word = listWords[newRand];
                if (CheckIsTaskPresent(list, word))
                {
                    i--;
                    continue;
                }
                var variants = new List<VariantDto>();
                var listForVars = listWords.Where(w => w.Id != word.Id).ToList();
                for (int j = 0; j < 4; j++)
                {
                    var varNum = rand.Next(listForVars.Count - 1);
                    var wordVariant = listForVars[varNum];

                    var strvar = string.Join(", ", wordVariant.Translates.Select(t => t.Text));
                    var varItem = new VariantDto() { Translation = strvar };
                    variants.Add(varItem);
                }
                variants.Add(new VariantDto()
                {
                    IsCorrect = true,
                    Translation = string.Join(", ", word.Translates.Select(t => t.Text))
                });
                variants.Sort((var1, var2) => string.Compare(var1.Translation, var2.Translation, true));
                list.Add(new TaskItemDto()
                {
                    Origin = word.Text,
                    Variants = variants,
                    Word = _mapper.Map<WordDto>(word)
                });
            }

            return list;
        }

        private bool CheckIsTaskPresent(List<TaskItemDto> tasks, Word word)
        {
            var pres = tasks.Any(t => t.Word.Id == word.Id);
            return pres;
        }


    }
}