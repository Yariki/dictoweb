using DictoInfrasctructure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DictoWeb.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class WordController : CoreController<TranslateController>
    {
        public WordController(ILogger<TranslateController> logger) : base(logger)
        {
        }
        
        
        
        
        
    }
}