using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealManager.Domain;

namespace RealManager.Services.Interfaces
{
    public interface IUserService
    {
        User CreateUser(string email, string password, string teamName);
    }
}
