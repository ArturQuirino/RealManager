using System;
using RealManager.Domain;

namespace RealManager.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        Team Create(Team team);
        Team Get(Guid teamId);
    }
}