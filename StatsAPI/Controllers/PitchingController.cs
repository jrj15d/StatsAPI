using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StatsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PitchingController : ControllerBase
    {
        private readonly ILogger<PitchingController> logger;
        public PitchingController(ILogger<PitchingController> logger)
        {
            this.logger = logger;
        }

        public ActionResult<IEnumerable<Pitching>> Get()
        {
            List<Pitching> list = new List<Pitching>();
            foreach (var row in DataContext.BaseballDatabase.Pitching)
                list.Add(new Pitching(row));

            if (list.Count > 0)
                return list;
            else
                return BadRequest();
        }

        [HttpGet("active")]
        public IEnumerable<Pitching> GetActive()
        {
            logger.LogInformation("Getting all active pitchers");

            var activePlayers = DataContext.BaseballDatabase.Active;
            var pitching = DataContext.BaseballDatabase.Pitching;
            return
                from player in activePlayers
                join pitcher in pitching on player.PlayerId equals pitcher.PlayerID
                select new Pitching(pitcher);
        }

        [HttpGet("{playerId}")]
        public ActionResult<IEnumerable<Pitching>> GetPlayer(string playerId)
        {
            logger.LogInformation($"Getting pitching stats for player with id: {playerId}");
            List<Pitching> list = new List<Pitching>();

            foreach (var row in DataContext.BaseballDatabase.PlayerPitching(playerId))
                list.Add(new Pitching(row));

            if (list.Count > 0)
                return list;
            else
                return BadRequest();

        }
    }
}
