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

        [HttpPost("add")]
        public IActionResult Add([FromBody] TranslateResultDto translateResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _wordService.AddNewWord(translateResult);
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
                return Ok();
            }
            catch (Exception e)
            {
                Log(e.Message);
                return BadRequest(e);
            }
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