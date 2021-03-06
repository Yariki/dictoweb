﻿using System;
using System.Threading.Tasks;
using AutoMapper;
using DictoInfrasctructure.Core;
using DictoInfrasctructure.Dtos;
using DictoServices.Interfaces;
using DictoWeb.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DictoWeb.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class TranslateController : CoreController<TranslateController>
    {
        private ITranslationService _translationService;
        private IWordService _wordService;
        private IMapper _mapper;

        public TranslateController(ITranslationService translationService,IMapper mapper, ILogger<TranslateController> logger)
            :base(logger)
        {
            _mapper = mapper;
            _translationService = translationService;
        }

        [HttpPost("translate")] 
        public async Task<IActionResult> Translate([FromBody] TranslateQueryDto translateQueryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _translationService.Translate(translateQueryDto);
                if (result == null)
                {
                    return BadRequest("There is no  translation.");
                }
                var mappedResult = _mapper.Map<TranslateResultDto>(result);
                return Json(mappedResult);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        
        
        

    }
}