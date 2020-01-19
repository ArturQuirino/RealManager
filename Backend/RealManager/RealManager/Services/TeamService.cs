using RealManager.Domain;
using RealManager.Repositories.Interfaces;
using RealManager.Services.Interfaces;

namespace RealManager.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        public TeamService(ITeamRepository teamRepository){
            _teamRepository = teamRepository;
        }

        public Team CreateTeam(Team team){
            return _teamRepository.Create(team);
        }
    }
}