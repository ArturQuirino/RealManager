using System.Collections.Generic;
using RealManager.Domain;
using RealManager.Repositories.Models;

namespace Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        List<PlayerDb> Get();

        PlayerDb Get(string id);

        Player Create(Player playerdb);

        void update(string id, PlayerDb playerdb);

        void Remove(PlayerDb playerDb);

        void Remove(string id);
    }
}