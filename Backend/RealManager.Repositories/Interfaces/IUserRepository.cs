using RealManager.Domain;

namespace RealManager.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetByEmail(string email);
    }
}
