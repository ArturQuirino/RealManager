using RealManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealManager.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User Add(User user);
    }
}
