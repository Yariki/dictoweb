using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using DictoInfrasctructure.Core;
using DictoInfrasctructure.Dtos;
using DictoServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DictoWeb.Controllers
{
    [Authorize]
    [Route("api/memory")]
    public class SuperMemoryController : CoreController<SuperMemoryController>
    {
        private IMemoryService _service;
        private IMapper _mapper;

        public SuperMemoryController(IMemoryService service, IMapper mapper, ILogger<SuperMemoryController> logger) : base(logger)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("statistic")]
        public async Task<IActionResult> GetStatistics()
        {
            try
            {
                return Ok(await _service.GetStatistics(GetUserName()));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateRepetition([FromBody] MemoryRepeatQueryDto query)
        {
            try
            {
                return Ok(await _service.GenerateRepetition(query, GetUserName()));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}