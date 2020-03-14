using RealManager.Domain;
using RealManager.Repositories.Interfaces;
using RealManager.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealManager.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DataContext _dataContext;
        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public User Create(User user)
        {
            UserDb userDb = new UserDb();
            userDb.Email = user.Email;
            userDb.Password = user.Password;
            userDb.TeamId = user.TeamId;
            userDb.Id = user.Id;


            _dataContext.Users.Add(userDb);
            _dataContext.SaveChanges();

            return user;
        }

        public User GetByEmail(string email)
        {
            UserDb userDb = _dataContext.Users.FirstOrDefault(u => u.Email == email);

            if(userDb == null)
            {
                return null;
            }

            User user = new User()
            {
                Email = userDb.Email,
                Id = userDb.Id,
                TeamId = userDb.TeamId,
                Password = userDb.Password
            };

            return user;
        }
    }
}
