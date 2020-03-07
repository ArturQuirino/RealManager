using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealManager.Controllers.Requests;
using RealManager.Domain;
using RealManager.Services.Interfaces;

namespace RealManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("/")]
        public User RunFriendly([FromBody]UserRequest createUserRequest)
        {
            return _userService.CreateUser(createUserRequest.Email, createUserRequest.Password, createUserRequest.TeamName);
        }
    }
}