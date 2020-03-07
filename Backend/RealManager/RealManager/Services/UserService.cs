using RealManager.Domain;
using RealManager.Repositories.Interfaces;
using RealManager.Services.Interfaces;
using System;

namespace RealManager.Services
{
    public class UserService : IUserService
    {
        public UserService(){
        }

        public User CreateUser(string email, string password, string teamName){
            User user = new User();
            user.Email = email;
            user.Password = password;
            user.TeamName = teamName;
            user.TeamId = Guid.NewGuid();
            return user;
        }
    }
}