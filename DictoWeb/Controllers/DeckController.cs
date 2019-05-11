using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using DictoData.Model;
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
        private IMapper _mapper;

        public DeckController(IDeckService deckService, IMapper mapper, ILogger<DeckController> logger) : base(logger)
        {
            _deckService = deckService;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetDeckList()
        {
            try
            {
                var list = await _deckService.Get(GetUserName());
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