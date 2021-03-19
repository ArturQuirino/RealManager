using RealManager.Domain;
using RealManager.Repositories.Models;
using RealManager.Repositories.Interfaces;
using AutoMapper;

namespace RealManager.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private DataContext _dataContext;
        private readonly IMapper _mapper;
        public PlayerRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public Player Create(Player player)
        {
            var playerDb = _mapper.Map<PlayerDb>(player);

            _dataContext.Players.Add(playerDb);
            _dataContext.SaveChanges();

            return player;
        }
    }
}