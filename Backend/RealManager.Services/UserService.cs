using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RealManager.Domain;
using RealManager.Repositories.Interfaces;
using RealManager.Services.Interfaces;
using RealManager.Shared;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RealManager.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILeagueRepository _leagueRepository;
        private readonly ITeamService _teamService;
        private readonly AppSettings _appSettings;
        public UserService(IUserRepository userRepository, ITeamService teamService, ILeagueRepository leagueRepository, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _teamService = teamService;
            _leagueRepository = leagueRepository;
            _appSettings = appSettings.Value;
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

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }
    }
}