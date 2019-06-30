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
using DictoServices.Extensions;
using DictoServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SQLitePCL;

namespace DictoServices.Services
{
    public class MemoryService : CoreService, IMemoryService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MemoryService(ILogger<MemoryService> logger, IUnitOfWork unitOfWork, IMapper mapper)
        :base(logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MemoryInfoDto> GetStatistics(string userName)
        {

            var result = await GetSettings(userName);

            var newWords = GlobalConst.DefaultNewWords;
            var minutes = GlobalConst.DefaultMinutes;
            
            if (result.Item2 == null)
            {
                var setting  = new Setting(){CountNew = newWords, Minute = minutes,UserId = result.Item1.Id, LastUsedSM2 = DateTime.Today};
                _unitOfWork.Repository<Setting>().Set.Add(setting);
                _unitOfWork.SaveChanges();
            }
            else
            {
                newWords = result.Item2.CountNew;
                minutes = result.Item2.Minute;
            }

            var wordsLess = _unitOfWork.Repository<Word>().Set.Include(w => w.SuperMemory)
                .Count(w => w.SuperMemory.EF < 2.0);
            var wordGreatter = _unitOfWork.Repository<Word>().Set.Include(w => w.SuperMemory)
                .Count(w => w.SuperMemory.EF > 2.0 && w.SuperMemory.EF < 2.5);
            var inProcess =  _unitOfWork.Repository<Word>().Set.Include(w => w.SuperMemory)
                .Count(w => w.SuperMemory.EF > 0.0);


            return new MemoryInfoDto(){CountEFLess2 = wordsLess, CountEFGreater2 = wordGreatter, CountInProcess = inProcess, NewWords = newWords, Minutes = minutes};
        }

        public async Task<MemoryRepeatResultDto> GenerateRepetition(MemoryRepeatQueryDto query, string userName)
        {
            var result = new MemoryRepeatResultDto();

            var userSettings = await GetSettings(userName);
            var lastDate = userSettings.Item2.LastUsedSM2;
            var missingDays = GetMissingDay(lastDate);

            var dates = new List<DateTime>();

            for (int i = 0; i < missingDays; i++)
            {
                lastDate = lastDate.AddDays(1);
                dates.Add(lastDate);
            }

            var todayRepetition = await _unitOfWork.Repository<Word>()
                .GetFilteredAsync(w => dates.Contains(w.SuperMemory.NextRepetition));
            foreach (var word in todayRepetition)
            {
                result.RepeatedWords.Add(_mapper.Map<WordDto>(word));
            }

            if (query.NewWords > 0)
            {
                var withoutRepetition =
                    await _unitOfWork.Repository<Word>().GetFilteredAsync(w => w.SuperMemory.Repetition == 0);
                if (withoutRepetition.Count() > query.NewWords)
                {
                    var count = withoutRepetition.Count();
                    var rand = new Random();
                    for (int i = 0; i < query.NewWords; i++)
                    {
                        var index = rand.Next(0, count);
                        result.NewWords.Add(_mapper.Map<WordDto>(withoutRepetition.ElementAt(index)));
                    }
                }
                else
                {
                    foreach (var word in withoutRepetition)
                    {
                        result.NewWords.Add(_mapper.Map<WordDto>(word));
                    }
                }
            }

            SaveSettings(query,userSettings.Item2);

            return result;
        }



        private int GetMissingDay(DateTime last)
        {
            int day = 1;
            DateTime lastDate = last.Date;
            DateTime nowDate = DateTime.Today;
            TimeSpan delta = nowDate.Subtract(lastDate);
            day = delta.Days;
            return day;
        }

        private async Task<Tuple<User,Setting>> GetSettings(string userName)
        {
            var user = await _unitOfWork.GetUser(userName);
            var settings = await _unitOfWork.Repository<Setting>().GetFilteredAsync(s => s.UserId == user.Id);
            return new Tuple<User, Setting>(user,settings.FirstOrDefault());
        }

        private void SaveSettings(MemoryRepeatQueryDto query, Setting setting)
        {
            setting.CountNew = query.NewWords;
            setting.Minute = query.Minutes;
            setting.LastUsedSM2 = DateTime.Today;
            _unitOfWork.SaveChanges();
        }

    }
}