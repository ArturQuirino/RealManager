using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealManager.Domain;
using RealManager.Services.Interfaces;

namespace RealManager.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        private readonly ILeagueService _leagueService;
        public LeagueController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [HttpGet]
        [Route("Team")]
        public List<League> GetLeagueFromTeamId()
        {
            var teamId = User.Claims.Where(c => c.Type == "TeamId").FirstOrDefault().Value;
            return _leagueService.GetLeagueFromTeamId(new Guid(teamId));
        }
    }
}