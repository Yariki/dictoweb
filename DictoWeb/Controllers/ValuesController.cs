using System.Collections.Generic;
using DictoInfrasctructure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace DictoWeb.Controllers
{
    [Route("api/[controller]"), Authorize]
    public class ValuesController : CoreController<ValuesController>
    {
        public ValuesController(ILogger<ValuesController> logger)
            :base(logger)
        {
            
        }

        [HttpPost("getvalues")]
        public IActionResult Get()
        {
            return Ok(new List<string> {"one", "two"});
        }
        
    }
}