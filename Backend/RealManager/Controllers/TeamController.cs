using Microsoft.AspNetCore.Mvc;
using RealManager.Domain;
using RealManager.Services.Interfaces;
using System;

namespace RealManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost]
        [Route("")]
        public Team Post([FromBody]Team team)
        {
            return _teamService.CreateTeam(team);
        }

        [HttpGet]
        [Route("{teamId}")]
        public Team Get([FromRoute]Guid teamId)
        {
            return _teamService.GetTeam(teamId);
        }

        [HttpPut]
        [Route("")]
        public Team Put([FromBody]Team team)
        {
            return _teamService.UpdateTeam(team);
        }
    }
}
