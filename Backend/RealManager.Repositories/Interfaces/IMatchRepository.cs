using System;
using System.Collections.Generic;
using RealManager.Domain;

namespace RealManager.Repositories.Interfaces
{
    public interface IMatchRepository
    {
        Match Create(Match match);
        Match GetById(Guid matchId);
        List<Match> GetMatchesByTeam(Guid teamId);
    }
}