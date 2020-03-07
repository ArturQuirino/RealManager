using System.Collections.Generic;
using RealManager.Domain;

namespace RealManager.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        Team Create(Team team);
    }
}