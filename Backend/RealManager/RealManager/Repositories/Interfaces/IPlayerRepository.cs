using System.Collections.Generic;
using RealManager.Domain;
using RealManager.Repositories.Models;

namespace RealManager.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        List<Player> GetAll();

        Player Get(string id);

        Player Create(Player playerdb);

        void Update(string id, PlayerDb playerdb);

        void Remove(PlayerDb playerDb);

        void Remove(string id);
    }
}