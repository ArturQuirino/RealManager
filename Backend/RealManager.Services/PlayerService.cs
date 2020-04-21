using RealManager.Domain;
using RealManager.Domain.Enums;
using RealManager.Repositories.Interfaces;
using RealManager.Shared;
using Services.Interfaces;
using System;
using System.Linq;

namespace RealManager.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerService(IPlayerRepository playerRepository){
            _playerRepository = playerRepository;
        }

        public Player CreatePlayer(Player player){
            return _playerRepository.Create(player);
        }

        public Player CreateRandomPlayer(Position? position = null, Guid? teamId = null)
        {
            Player newPlayer = new Player();

            var random = new Random();
            int randomNameIndex = random.Next(Constants.POSSIBLENAMES.Length);
            int randomSurnameIndex = random.Next(Constants.POSSIBLESURNAMES.Length);

            newPlayer.Name = Constants.POSSIBLENAMES[randomNameIndex] + ' ' + Constants.POSSIBLESURNAMES[randomSurnameIndex];

            newPlayer.Pace = random.Next(1, 100);
            newPlayer.Pass = random.Next(1, 100);
            newPlayer.Physical = random.Next(1, 100);
            newPlayer.Defence = random.Next(1, 100);
            newPlayer.Shoot = random.Next(1, 100);
            newPlayer.Drible = random.Next(1, 100);
            newPlayer.Overall = Convert.ToInt32(Queryable.Average((new int[] {
                newPlayer.Pace,
                newPlayer.Pass,
                newPlayer.Physical,
                newPlayer.Defence,
                newPlayer.Shoot,
                newPlayer.Drible,
            }).AsQueryable()));

            if (position.HasValue)
            {
                newPlayer.Position = position.Value;
            }
            else
            {
                Array posiblePositions = Enum.GetValues(typeof(Position));
                Position chosenPosition = (Position)posiblePositions.GetValue(random.Next(posiblePositions.Length));
                newPlayer.Position = chosenPosition;
            }

            if (teamId.HasValue)
            {
                newPlayer.TeamId = teamId.Value;
            }

            _playerRepository.Create(newPlayer);

            return newPlayer;
        }
    }
}