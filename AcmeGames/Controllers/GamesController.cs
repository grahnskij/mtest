using AcmeGames.Interfaces;
using AcmeGames.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AcmeGames.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/games")]
    public class GamesController : Controller
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<GamesListViewModel>))]
        [ProducesResponseType(400)]
        public IActionResult GetUserGamesList(string id){
            if(String.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }
            var result = _gameService.GetGamesForUser(id);
            return Ok(result);
        }
    }
}
