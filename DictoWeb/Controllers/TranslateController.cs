using System;
using System.Threading.Tasks;
using DictoDtos.Dtos;
using DictoServices.Interfaces;
using DictoWeb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DictoWeb.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class TranslateController : CoreController<TranslateController>
    {
        private ITranslationService _translationService;

        public TranslateController(ITranslationService translationService, ILogger<TranslateController> logger)
            :base(logger)
        {
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
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        

    }
}