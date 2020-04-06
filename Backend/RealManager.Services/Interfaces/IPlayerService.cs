using RealManager.Domain;
using RealManager.Domain.Enums;
using System;

namespace Services.Interfaces
{
    public interface IPlayerService
    {
        Player CreatePlayer(Player player);
        Player CreateRandomPlayer(Position? position = null, Guid? teamId = null);
    }
}