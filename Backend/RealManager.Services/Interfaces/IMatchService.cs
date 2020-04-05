using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealManager.Domain;

namespace RealManager.Services.Interfaces
{
    public interface IMatchService
    {
        bool RunMatchEvent(int time);
        Match RunFriendly(Guid homeTeamId, Guid awayTeamId);
    }
}
