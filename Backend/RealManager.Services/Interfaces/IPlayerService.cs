using RealManager.Domain;
using System;

namespace Services.Interfaces
{
    public interface IPlayerService
    {
        Player CreatePlayer(Player player);
        Player CreateRandomPlayer(Position? position = null, Guid? teamId = null);
    }
}