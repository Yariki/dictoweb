using System.Collections.Generic;
using AutoMapper;
using DictoData.Interfaces;
using DictoData.Model;
using DictoInfrasctructure.Core;
using DictoInfrasctructure.Dtos;
using DictoInfrasctructure.Enums;
using DictoInfrasctructure.Extensions;
using DictoServices.Interfaces;
using Microsoft.Extensions.Logging;

namespace DictoServices.Services
{
    public class WordService : CoreService,IWordService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WordService(ILogger logger,IUnitOfWork unitOfWork, IMapper mapper) : base(logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public void AddNewWord(TranslateDto translate)
        {
            var word = new Word(){Text = translate.Original,Level = LevelType.First,Phonetic = translate.Phonetic,SuperMemory = new SuperMemory(),UserId = 1};
            foreach (var pair in translate.Translate)
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
        
    }
}