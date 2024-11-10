using Entities;
using System.Text.Json;
using Repositories;

namespace Services
{
    public class UserService

    {
        UserRepositories repository = new();
        public UserService()
        { }

            public IEnumerable<string> Get()
            {
                return new string[] { "value1", "value2" };
            }
            public string Get(int id)
            {
                return "value";
            }
            public User Login(string UserName, string Password)
            {
                return repository.Login(UserName, Password);
            }
            public User Post(User user)
            {
                
                return repository.Post(user);

            }

            public User Put(int id, User userToUpdate)
            {
            return repository.Put(id, userToUpdate);
            }

            public void Delete(int id)
            {
            repository.Delete(id);
        }
        }
    }

 
