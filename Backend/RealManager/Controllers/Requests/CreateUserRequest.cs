﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealManager.Controllers.Requests
{
    public class CreateUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string TeamName { get; set; }
    }
}
