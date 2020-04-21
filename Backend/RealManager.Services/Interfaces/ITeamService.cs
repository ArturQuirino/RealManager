using RealManager.Domain;
using System;

namespace RealManager.Services.Interfaces
{
    public interface ITeamService
    {
        Team CreateTeam(Team team);
        Team GetTeam(Guid teamId);
        Team CreateRandomTeam(string teamName);
    }
}