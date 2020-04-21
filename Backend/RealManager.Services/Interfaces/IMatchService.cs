using System;
using System.Collections.Generic;
using RealManager.Domain;

namespace RealManager.Services.Interfaces
{
    public interface IMatchService
    {
        bool RunMatchEvent(int time);
        Match RunFriendly(Guid homeTeamId, Guid awayTeamId);
        List<Match> GetMatchesByTeamId(Guid teamId);
        Match GetMatchById(Guid matchId);
    }
}
