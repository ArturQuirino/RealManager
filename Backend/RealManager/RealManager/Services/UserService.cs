using RealManager.Domain;
using RealManager.Repositories.Interfaces;
using RealManager.Services.Interfaces;

namespace RealManager.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITeamService _teamService;
        public UserService(IUserRepository userRepository, ITeamService teamService)
        {
            _userRepository = userRepository;
            _teamService = teamService;
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

            return addedUser;
        }
    }
}