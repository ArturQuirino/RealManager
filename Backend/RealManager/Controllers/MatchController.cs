using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealManager.Domain;
using RealManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealManager.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;
        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpGet]
        [Route("/{time}")]
        public bool Get([FromRoute]int time)
        {
            return _matchService.RunMatchEvent(time);
        }

        [HttpPost]
        [Route("/Friendly")]
        public Match RunFriendly([FromBody]List<string> teams)
        {
            return _matchService.RunFriendly(Guid.Parse(teams.FirstOrDefault()), Guid.Parse(teams.LastOrDefault()));
        }

        [HttpGet]
        [Route("Team/{teamId}")]
        public List<Match> GetMatchesByTeamId([FromRoute]Guid teamId)
        {
            return _matchService.GetMatchesByTeamId(teamId);
        }

        [HttpGet]
        [Route("{matchId}")]
        public Match GetMatchById([FromRoute]Guid matchId)
        {
            return _matchService.GetMatchById(matchId);
        }
    }
}
