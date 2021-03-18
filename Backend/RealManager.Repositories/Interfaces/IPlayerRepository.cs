using RealManager.Domain;
using System.Collections.Generic;

namespace RealManager.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        List<Player> GetAllPlayers();
        
        Player Create(Player player);
    }
}