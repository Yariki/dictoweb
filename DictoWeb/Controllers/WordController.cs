using System;
using System.Net;
using DictoInfrasctructure.Core;
using DictoInfrasctructure.Dtos;
using DictoServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DictoWeb.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class WordController : CoreController<TranslateController>
    {
        private IWordService _wordService;

        public WordController(ILogger<TranslateController> logger, IWordService wordService) : base(logger)
        {
            _wordService = wordService;
        }


        [HttpPost]
        public IActionResult Add([FromBody] TranslateDto translate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _wordService.AddNewWord(translate);
            }
            catch (Exception e)
            {
                Log(e.ToString());
                return BadRequest(e.Message);
            }
            return Ok();
        }
        
        
        
    }
}