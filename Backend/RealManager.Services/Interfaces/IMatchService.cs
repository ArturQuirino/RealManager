using System;
using RealManager.Domain;

namespace RealManager.Services.Interfaces
{
    public interface IMatchService
    {
        bool RunMatchEvent(int time);
        Match RunFriendly(Guid homeTeamId, Guid awayTeamId);
    }
}
