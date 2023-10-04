using primeiraAPI.Models;

namespace primeiraAPI.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
    }
}