using System;
using System.Collections.Generic;
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
        [Route("Team/{teamId}")]
        public List<League> GetLeagueFromTeamId([FromRoute]Guid teamId)
        {
            return _leagueService.GetLeagueFromTeamId(teamId);
        }
    }
}