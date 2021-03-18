using RealManager.Domain;
using RealManager.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IPlayerService
    {
        List<Player> GetAllPlayers();
        Player CreatePlayer(Player player);
        Player CreateRandomPlayer(Position? position = null, Guid? teamId = null);
    }
}