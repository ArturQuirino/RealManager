using System.Collections.Generic;
using RealManager.Domain;

namespace RealManager.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        List<Team> Get();

        Team Get(string id);

        Team Create(Team player);

        void Update(string id, Team team);

        void Remove(Team team);

        void Remove(string id);
    }
}