using System;
using RealManager.Domain;

namespace RealManager.Repositories.Interfaces
{
    public interface ILeagueRepository
    {
        League AddTeamToLeague(Team team);
    }
}