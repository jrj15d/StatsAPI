using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StatsAPI.Models;
using StatsAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatsAPI.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly ILogger<PlayersController> logger;

        public PlayersController(ILogger<PlayersController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<Player> Get()
        {
            logger.LogInformation("Getting all players");
            var rows = DataContext.BaseballDatabase.Players;

            foreach (var row in rows)
                yield return new Player(row);
        }

        [HttpGet("active")]
        public IEnumerable<Player> GetActive()
        {
            logger.LogInformation("Getting all active players");

            return
                from player in Get()
                where player.DateFinalGame?.Year >= 2021
                select player;
        }

        [HttpGet("{playerId}")]
        public ActionResult<Player> GetPlayer(string playerId)
        {
            logger.LogInformation($"Getting player with id: {playerId}");

            foreach (var player in Get())
            {
                if (player.PlayerId == playerId)
                    return player;
            }

            return BadRequest();

        }
    }
}
