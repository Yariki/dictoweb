using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DictoInfrasctructure.Core;
using DictoInfrasctructure.Dtos;
using DictoServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DictoWeb.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class DeckController : CoreController<DeckController>
    {
        private IDeckService _deckService;

        public DeckController(IDeckService deckService, ILogger<DeckController> logger) : base(logger)
        {
            _deckService = deckService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetDeckList()
        {
            try
            {
                var list = await _deckService.Get(GetUserName());
                list = list.Where(d => d.Id != 0).ToList();
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddDeck([FromBody]DeckDto deck)
        {
            try
            {
                await _deckService.AddItem(GetUserName(),deck);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return Ok();
        }

        [HttpPost("edit")]
        public IActionResult UpdateDeck([FromBody] DeckDto deck)
        {
            try
            {
                _deckService.UpdateItem(deck);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok();
        }



    }
}