using RealManager.Domain;
using RealManager.Repositories.Interfaces;
using RealManager.Services.Interfaces;
using System;

namespace RealManager.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILeagueRepository _leagueRepository;
        private readonly ITeamService _teamService;
        public UserService(IUserRepository userRepository, ITeamService teamService, ILeagueRepository leagueRepository)
        {
            _userRepository = userRepository;
            _teamService = teamService;
            _leagueRepository = leagueRepository;
        }

        public User CreateUser(string email, string password, string teamName){
            User user = new User
            {
                Email = email,
                Password = password
            };

            Team usersTeam = _teamService.CreateRandomTeam(teamName);

            user.TeamId = usersTeam.Id;

            var addedUser = _userRepository.Create(user);

            _leagueRepository.AddTeamToLeague(usersTeam);

            return addedUser;
        }

        public User Login(string email, string password)
        {
            User user = _userRepository.GetByEmail(email);
            if(user == null)
            {
                throw new UnauthorizedAccessException();
            }

            if(user.Password != password)
            {
                throw new UnauthorizedAccessException();
            }

            return user;
        }
    }
}