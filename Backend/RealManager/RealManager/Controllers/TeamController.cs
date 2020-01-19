using Microsoft.AspNetCore.Mvc;
using RealManager.Domain;
using RealManager.Services.Interfaces;

namespace RealManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
    }
}
