using System;
using System.Collections.Generic;
using RealManager.Domain;

namespace RealManager.Repositories.Interfaces
{
    public interface ILeagueRepository
    {
        League AddTeamToLeague(Team team);
        League GetLeagueFromTeamId(Guid teamId);
        List<League> GetLeagueFromIdLeague(Guid idLeague);
        List<League> UpdateLeague(List<League> leagues);
    }
}