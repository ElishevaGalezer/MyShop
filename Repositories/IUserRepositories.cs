using Entities;

namespace Repositories
{
    public interface IUserRepositories
    {
        string Get(int id);
       Task<User> Login(string UserName, string Password);
        Task<User> Post(User user);
        Task Put(int id, User userToUpdate);
    }
}