﻿using Microsoft.AspNetCore.Http;
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
    public class BattingController : ControllerBase
    {
        private readonly ILogger<BattingController> logger;
        public BattingController(ILogger<BattingController> logger)
        {
            this.logger = logger;
        }

        public ActionResult<IEnumerable<Batting>> Get()
        {
            List<Batting> list = new List<Batting>();

            foreach (var row in DataContext.BaseballDatabase.Batting)
                list.Add(new Batting(row));

            if (list.Count > 0)
                return list;
            else
                return BadRequest();
        }

        [HttpGet("active")]
        public IEnumerable<Batting> GetActive()
        {
            logger.LogInformation("Getting all active batters");

            var activePlayers = DataContext.BaseballDatabase.Active;
            var batting = DataContext.BaseballDatabase.Batting;
            return
                from player in activePlayers
                join batter in batting on player.PlayerId equals batter.PlayerID
                select new Batting(batter);
        }

        [HttpGet("{playerId}")]
        public ActionResult<IEnumerable<Batting>> GetPlayer(string playerId)
        {
            logger.LogInformation($"Getting batting stats for player with id: {playerId}");
            List<Batting> list = new List<Batting>();

            foreach (var row in DataContext.BaseballDatabase.PlayerBatting(playerId))
                list.Add(new Batting(row));

            if (list.Count > 0)
                return list;
            else
                return BadRequest();

        }
    }
}
