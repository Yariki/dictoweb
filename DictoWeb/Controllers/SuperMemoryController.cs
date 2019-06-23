using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DictoInfrasctructure.Core;
using DictoInfrasctructure.Dtos;
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
        public SuperMemoryController(ILogger<SuperMemoryController> logger) : base(logger)
        {
        }


        public IActionResult GetStatistics()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("generate")]
        public IActionResult GenerateRepetition([FromBody] MemoryRepeatQueryDto query)
        {
            throw new NotImplementedException();
        }

    }
}