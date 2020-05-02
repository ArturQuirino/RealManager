using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealManager.Domain;
using RealManager.Services.Interfaces;
using System;
using System.Linq;

namespace RealManager.Controllers
{
    [Authorize]
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
        [Route("")]
        public Team Get()
        {
            var teamId = User.Claims.Where(c => c.Type == "TeamId").FirstOrDefault().Value;
            return _teamService.GetTeam(new Guid(teamId));
        }

        [HttpPut]
        [Route("")]
        public Team Put([FromBody]Team team)
        {
            return _teamService.UpdateTeam(team);
        }
    }
}
