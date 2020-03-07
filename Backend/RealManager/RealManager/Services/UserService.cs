using RealManager.Domain;
using RealManager.Repositories.Interfaces;
using RealManager.Services.Interfaces;
using System;

namespace RealManager.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository){
            _userRepository = userRepository;
        }

        public User CreateUser(string email, string password, string teamName){
            User user = new User
            {
                Email = email,
                Password = password,
                TeamId = Guid.NewGuid()
            };

            var addedUser = _userRepository.Add(user);

            return addedUser;
        }
    }
}