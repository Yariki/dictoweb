using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DictoInfrasctructure.Core;
using DictoInfrasctructure.Dtos;
using DictoInfrasctructure.Extensions;
using DictoServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DictoWeb.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class LevelController : CoreController<LevelController>
    {
        private readonly IFirstLevelService _firstLevelService;
        private readonly ISecondLevelService _secondLevelService;
        private readonly IThirdLevelService _thirdLevelService;

        public LevelController(IFirstLevelService firstLevelService, ISecondLevelService secondLevelService, IThirdLevelService thirdLevelService, ILogger<LevelController> logger) : base(logger)
        {
            _firstLevelService = firstLevelService;
            _secondLevelService = secondLevelService;
            _thirdLevelService = thirdLevelService;
        }

        [HttpGet("level1")]
        public async Task<IActionResult> GenerateTasksForFirstLevel()
        {
            try
            {
                var result = await _firstLevelService.GenerateDataLevelAsync(GetUserName());
                return Ok(result);
            }
            catch (Exception e)
            {
                Log(e.Message);
                return BadRequest(e);
            }
        }

        [HttpGet("level2")]
        public async Task<IActionResult> GenerateTaskForSecondLevel()
        {
            try
            {
                var result = await _secondLevelService.GenerateDataLevelAsync(GetUserName());
                return Ok(result);
            }
            catch (Exception e)
            {
                Log(e.Message);
                return BadRequest(e);
            }
        }


        [HttpGet("level3")]
        public async Task<IActionResult> GenerateTaskForThirdLevel()
        {
            try
            {
                var result = await _thirdLevelService.GenerateTasksAsync(GetUserName());
                return Ok(result);
            }
            catch (Exception e)
            {
                Log(e.Message);
                return BadRequest(e);
            }
        }

        

    }
}