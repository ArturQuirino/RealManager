using System.Collections.Generic;
using RealManager.Domain;
using RealManager.Repositories.Models;

namespace RealManager.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        Player Create(Player player);
    }
}