using RealManager.Domain;
using RealManager.Repositories.Models;
using RealManager.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using RealManager.Domain.Enums;

namespace RealManager.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private DataContext _dataContext;
        public PlayerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Player> GetAllPlayers()
        {
            var players = _dataContext.Players.ToList();
            // Player player = new Player("Davi Quirino");
            //List<Player> players = new List<Player>
            //{
            //    player
            //};
            var playersFromTeam = new List<Player>();

            foreach (PlayerDb playerDb in players)
            {
                playersFromTeam.Add(new Player()
                {
                    Id = playerDb.Id,
                    Defence = playerDb.Defence,
                    Drible = playerDb.Drible,
                    Name = playerDb.Name,
                    Pace = playerDb.Pace,
                    Pass = playerDb.Pass,
                    Physical = playerDb.Physical,
                    Position = (Position)playerDb.Position,
                    Shoot = playerDb.Shoot,
                    TeamId = playerDb.TeamId,
                    Overall = playerDb.Overall
                });
            }
            return playersFromTeam;
        }

        public Player Create(Player player)
        {
            PlayerDb playerDb = new PlayerDb
            {
                Id = player.Id,
                Defence = player.Defence,
                Drible = player.Drible,
                Name = player.Name,
                Pace = player.Pace,
                Pass = player.Pass,
                Physical = player.Physical,
                Position = (int)player.Position,
                Shoot = player.Shoot,
                Overall = player.Overall,
                TeamId = player.TeamId
            };

            _dataContext.Players.Add(playerDb);
            _dataContext.SaveChanges();

            return player;
        }
    }
}