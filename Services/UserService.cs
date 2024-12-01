using Entities;
using System.Text.Json;
using Repositories;
using Zxcvbn;

namespace Services
{
    public class UserService:IUserService


    {
        IUserRepositories _userRepository;
        public UserService(IUserRepositories userRepository)
        {
            _userRepository = userRepository;
        }

            public IEnumerable<string> Get()
            {
                return new string[] { "value1", "value2" };
            }
            public string Get(int id)
            {
                return "value";
            }
            public async Task<User> Login(string UserName, string Password)
            {
                return await _userRepository.Login(UserName, Password);
            }
            public async Task<User> Post(User user)
            {
                
                return await _userRepository.Post(user);

            }
        public int Password(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password).Score;
            
            return result;
        }
            public async Task Put(int id, User userToUpdate)
            {
             await _userRepository.Put(id, userToUpdate);
            }

            public void Delete(int id)
            {
            _userRepository.Delete(id);
        }
        }
    }

 
