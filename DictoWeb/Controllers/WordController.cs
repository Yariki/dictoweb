using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using DictoData.Model;
using DictoInfrasctructure.Core;
using DictoInfrasctructure.Dtos;
using DictoInfrasctructure.Enums;
using DictoInfrasctructure.Extensions;
using DictoServices.Interfaces;
using DictoServices.Services;
using DictoWeb.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Logging;

namespace DictoWeb.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class WordController : CoreController<WordController>
    {
        private IWordService _wordService;
        private IMapper _mapper;

        public WordController(ILogger<WordController> logger, IWordService wordService, IMapper mapper) : base(logger)
        {
            _wordService = wordService;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var list = await _wordService.GetAllWords();
                var words = new List<WordDto>();
                foreach (var word in list)
                {
                    var w = _mapper.Map<WordDto>(word);
                    foreach (var wordTranslate in word.Translates)
                    {
                        w.Translates.Add(_mapper.Map<TranslateDto>(wordTranslate));
                    }
                    words.Add(w);
                }
                return Ok(words);
            }
            catch (Exception e)
            {
                Log(e.ToString());
            }
            return BadRequest();
        }

        [HttpPost("page")]
        public async Task<IActionResult> GetPageAndFilterList([FromBody] WordPaginationDto wordPaginationDto)
        {
            try
            {
                var result = _wordService.GetPagedAndFilteredList(wordPaginationDto);
                return Ok(result);
            }
            catch (Exception e)
            {
                Log(e.ToString());
            }

            return BadRequest();
        }
        

        [HttpGet("words")]
        public async Task<IActionResult> GetWordsWithoutDeck()
        {
            try
            {
                var list = await _wordService.GetWordWithoutDeck();
                var words = new List<WordDto>();
                foreach (var word in list)
                {
                    words.Add(_mapper.Map<WordDto>(word));
                }

                return Ok(words);
            }
            catch (Exception e)
            {
                Log(e.ToString());
            }

            return BadRequest();
        }

        [HttpGet("wordsdeck")]
        public async Task<IActionResult> GetDeckWords(int deckId)
        {
            try
            {
                var list = await _wordService.GetDeckWords(deckId);
                var words = new List<WordDto>();
                foreach (var word in list)
                {
                    words.Add(_mapper.Map<WordDto>(word));
                }
                return Ok(words);
            }
            catch (Exception e)
            {
                Log(e.ToString());
            }

            return BadRequest();
        }
        
        [HttpPost("add")]
        public IActionResult Add([FromBody] TranslateResultDto translateResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _wordService.AddNewWord(translateResult,GetUserName());
            }
            catch (Exception e)
            {
                Log(e.ToString());
                return BadRequest(e.Message);
            }
            return Ok();
        }


        [HttpPost("update")]
        public IActionResult Update([FromBody] WordDto word)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _wordService.UpdateWord(word);
                return Ok();
            }
            catch (Exception e)
            {
                Log(e.Message);
                return BadRequest(e);
            }
        }

        [HttpPost("updatelevel")]
        public IActionResult UpdateWordLevel([FromBody]WordLevelInfoDto wordInfoDto)
        {
            try
            {
                _wordService.UpdateWordLevel(wordInfoDto);
                return Ok();
            }
            catch (Exception e)
            {
                Log(e.Message);
                return BadRequest(e);
            }
        }

        [HttpPost("addwordtodeck")]
        public IActionResult UpdateWordsDeck([FromBody] DeckWordsDto deckWordsDto)
        {
            try
            {
                _wordService.UpdateWordsDesk(deckWordsDto);
                return Ok();
            }
            catch (Exception e)
            {
                Log(e.ToString());
            }

            return BadRequest();
        }
        
        [HttpPost("deletewordtodeck")]
        public IActionResult DeleteWordsDeck([FromBody] DeckWordsDto deckWordsDto)
        {
            try
            {
                if (deckWordsDto.IsNotNull())
                {
                    deckWordsDto.DeckId = 0;
                    _wordService.UpdateWordsDesk(deckWordsDto);
                }
                return Ok();
            }
            catch (Exception e)
            {
                Log(e.ToString());
            }
            return BadRequest();
        }
        
        
        
        [HttpGet("wordsinfo")]
        public async Task<IActionResult> GetWordsInfo()
        {
            var userName = this.User.GetUserName();
            try
            {

                var info = await _wordService.GetUserWordsInfo(userName);

                return Ok(info);
            }
            catch (Exception e)
            {
                Log(e.ToString());
                return BadRequest(e.Message);
            }
            return NotFound();
        }
    }
}