using RealManager.Domain;
using RealManager.Domain.Enums;
using RealManager.Repositories.Interfaces;
using RealManager.Services.Interfaces;
using Services.Interfaces;

namespace RealManager.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IPlayerService _plyerService;
        public TeamService(ITeamRepository teamRepository, IPlayerService plyerService)
        {
            _teamRepository = teamRepository;
            _plyerService = plyerService;
        }

        public Team CreateTeam(Team team){
            return _teamRepository.Create(team);
        }

        public Team CreateRandomTeam(string teamName)
        {
            Team newTeam = new Team
            {
                Name = teamName
            };

            for (int i=0; i < 23; i++)
            {
                Player newPlayer;
                if(i == 0)
                {
                    newPlayer = _plyerService.CreateRandomPlayer(Position.GK, newTeam.Id);
                    newTeam.Players.Add(newPlayer);
                    newTeam.Starters.Add(newPlayer);
                }
                else if (i >= 1 && i <= 4)
                {
                    newPlayer = _plyerService.CreateRandomPlayer(Position.DF, newTeam.Id);
                    newTeam.Players.Add(newPlayer);
                    newTeam.Starters.Add(newPlayer);
                }
                else if (i >= 5 && i <= 7)
                {
                    newPlayer = _plyerService.CreateRandomPlayer(Position.MF, newTeam.Id);
                    newTeam.Players.Add(newPlayer);
                    newTeam.Starters.Add(newPlayer);
                }
                else if (i >= 8 && i <= 10)
                {
                    newPlayer = _plyerService.CreateRandomPlayer(Position.ATA, newTeam.Id);
                    newTeam.Players.Add(newPlayer);
                    newTeam.Starters.Add(newPlayer);
                }
                else
                {
                    newPlayer = _plyerService.CreateRandomPlayer(teamId: newTeam.Id);
                    newTeam.Players.Add(newPlayer);
                }
            }

            _teamRepository.Create(newTeam);

            return newTeam;
        }
    }
}