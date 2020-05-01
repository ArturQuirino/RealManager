using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealManager.Domain;
using RealManager.Services.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealManager.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerService matchService)
        {
            _playerService = matchService;
        }

        [HttpPost]
        [Route("")]
        public Player Post([FromBody]Player player)
        {
            return _playerService.CreatePlayer(player);
        }
    }
}
