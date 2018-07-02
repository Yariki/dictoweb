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
    [Authorize]
    [Route("api/[controller]")]
    public class DeckController : CoreController<DeckController>
    {
        private IDeckService _deckService;

        public DeckController(IDeckService deckService, ILogger<DeckController> logger) : base(logger)
        {
        }

        [HttpGet("list")]
        public IActionResult GetDeckList()
        {
            try
            {
                var list = _deckService.Get(GetUserName());
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpPost("add")]
        public IActionResult AddDeck([FromBody]DeckDto deck)
        {
            try
            {
                _deckService.AddItem(GetUserName(),deck);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return Ok();
        }

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