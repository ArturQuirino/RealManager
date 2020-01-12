using RealManager.Domain;
using Repositories.Interfaces;
using Services.Interfaces;

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
    }
}