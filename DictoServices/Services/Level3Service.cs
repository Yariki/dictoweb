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
using DictoServices.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;

namespace DictoServices.Services
{
    public class Level3Service : CoreService, IThirdLevelService
    {
        private const int MAX_GENERATE_LEVEL = 10;

        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public Level3Service(ILogger<Level1Service> logger, IUnitOfWork unitOfWork, IMapper mapper) 
            : base(logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PazzleItemDto[]> GenerateTasksAsync(string userName)
        {
            var user = await GetUser(userName);
            var userId = user.First().Id;

            var words = await _unitOfWork.Repository<Word>()
                .GetFilteredAsync(w => w.Level == LevelType.Third && w.UserId == userId, "Translates");

            var wordsList = words.ToList();

            var rand = new Random(wordsList.Count());

            var generatedCount = wordsList.Count() >= MAX_GENERATE_LEVEL ? MAX_GENERATE_LEVEL : wordsList.Count();
            var count = wordsList.Count();

            var result = new List<PazzleItemDto>(generatedCount);

            for (int i = 0; i < generatedCount; i++)
            {
                var newRand = rand.Next(count);
                var word = wordsList[newRand];
                var trans = string.Join(", ", word.Translates.Select(t => t.Text));
                var origin = PazzleItemDto.GenerateOriginal(word.Text);
                var pazzle = PazzleItemDto.GeneratePazzle(origin);

                result.Add(new PazzleItemDto(){Original = origin, Pazzle = pazzle,Source = word.Text,Translate = trans,WordId = word.Id});

            }

            return result.ToArray();
        }

        public async Task<int> GetCount(string userName)
        {
            var user = await GetUser(userName);
            var userId = user.First().Id;

            var words = await _unitOfWork.Repository<Word>()
                .GetFilteredAsync(w => w.Level == LevelType.Third && w.UserId == userId, "Translates");

            return words.Count();
        }


        private async Task<IEnumerable<User>> GetUser(string userName)
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

            return users;
        }

    }
}