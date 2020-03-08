using RealManager.Domain;
using RealManager.Repositories.Models;
using RealManager.Repositories.Interfaces;

namespace RealManager.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private DataContext _dataContext;
        public PlayerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
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
                TeamId = player.TeamId
            };

            _dataContext.Players.Add(playerDb);
            _dataContext.SaveChanges();

            return player;
        }
    }
}